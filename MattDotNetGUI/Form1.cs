/*
 * Released as open source by NCC Group Plc - http://www.nccgroup.com/
 * 
 * Developed by Matt Lewis, (matt [dot] lewis [at] nccgroup.com)
 * 
 * http://www.github.com/nccgroup/matt.net
 * 
 * Released under AGPL. See LICENSE for more information
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Security.Cryptography;
using System.Threading;

namespace MattDotNetGUI
{

    public partial class Form1 : Form
    {
        private string CONFIG_FILE_PATH = Path.Combine(Application.StartupPath, "config.xml");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup default GUI options
            CatNETPath.Text = "C:\\Program Files (x86)\\Microsoft\\CAT.NET\\CATNetCmd.exe"; //Changed to match default CAT.NET x86 install path
            SourcePath.Text = "";
            DestPath.Text = "";

            //Load existing configuration if available
            try {
                //Load the config
                MattNetConfig config;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(MattNetConfig));
                StreamReader configFile = new StreamReader(CONFIG_FILE_PATH);
                config = (MattNetConfig)xmlSerializer.Deserialize(configFile);
                configFile.Close();

                //Initialize UI
                CatNETPath.Text = config.CatNetPath;
                SourcePath.Text = config.LastSrcDir;
                DestPath.Text = config.LastDstDir;
                CATtimeout.Text = config.CatTimeoutMinutes.ToString();
                CB_SQLInjection.Checked = config.CSQLEnabled;
                CB_CommandExecution.Checked = config.CCMdExecEnabled;
                CB_FileCanonicalisation.Checked = config.CFileCanonicalisationEnabled;
                CB_InformationDisclosure.Checked = config.CInfoDisclosureEnabled;
                CB_XSS.Checked = config.CXSSEnabled;
                CB_WebRedirection.Checked = config.CWebRedirectEnabled;
                CB_XPathInjection.Checked = config.CXPathEnabled;
                CB_LDAPInjection.Checked = config.CLDAPEnabled;
            } catch(Exception) {
                //Ignore, XML config will be (re)created on application exit
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Create a MattNetConfig object to serialize
            MattNetConfig config = new MattNetConfig();
            uint timeout;
            config.CatNetPath = CatNETPath.Text;
            config.LastSrcDir = SourcePath.Text;
            config.LastDstDir = DestPath.Text;
            if (UInt32.TryParse(CATtimeout.Text, out timeout))
            {
                config.CatTimeoutMinutes = timeout;
            }
            else
            {
                config.CatTimeoutMinutes = 5; //Default
            }
            config.CSQLEnabled = CB_SQLInjection.Checked;
            config.CCMdExecEnabled = CB_CommandExecution.Checked;
            config.CFileCanonicalisationEnabled = CB_FileCanonicalisation.Checked;
            config.CInfoDisclosureEnabled = CB_InformationDisclosure.Checked;
            config.CXSSEnabled = CB_XSS.Checked;
            config.CWebRedirectEnabled = CB_WebRedirection.Checked;
            config.CXPathEnabled = CB_XPathInjection.Checked;
            config.CLDAPEnabled = CB_LDAPInjection.Checked;

            //Write the configuration file
            XmlDocument configXml = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MattNetConfig));
            StreamWriter configFile = new StreamWriter(CONFIG_FILE_PATH);
            xmlSerializer.Serialize(configFile, config);
            configFile.Close();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();

            string rules = " /ruleid:";

            bool[] ruleChecks = { 
                                    CB_SQLInjection.Checked, CB_CommandExecution.Checked, CB_FileCanonicalisation.Checked, 
                                    CB_InformationDisclosure.Checked, CB_XSS.Checked, CB_WebRedirection.Checked, 
                                    CB_XPathInjection.Checked, CB_LDAPInjection.Checked };

            // build the cmd flags for CAT.NET rules based on the user input
            for (int r = 0; r < ruleChecks.Length; r++)
            {
                if (ruleChecks[r])
                {
                    rules += "+ACESEC0" + (r + 1).ToString() + ",";
                }
                else
                {
                    rules += "-ACESEC0" + (r + 1).ToString() + ",";
                }
            }
            // delete the last comma ','
            rules = rules.Substring(0, rules.Length - 1);

            progressBar1.Value = 0;
            progressBar1.Step = 0;
            progressBar1.PerformStep();
            progressBar1.Refresh();
            
            // create the database if first-time run
            if(!File.Exists("MattDotNet.sqlite")) 
            {
                DbFuncs.CreateDB();
            }
            if (File.Exists(CatNETPath.Text))
            {
                TraverseAndRun(SourcePath.Text, CatNETPath.Text, rules, DestPath.Text);
            }
            else
            {
                MessageBox.Show("Can't find CAT.NET. Check path and try again...");
            }
        }

        private void SourceButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SourcePath.Text = folderBrowserDialog1.SelectedPath; 
            }
        }

        private void CatNETButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                CatNETPath.Text = folderBrowserDialog1.SelectedPath; 
            }
        }

        private void DestButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DestPath.Text = folderBrowserDialog1.SelectedPath; 
            }
        }

        // if the user selects a results file, ask if they want to open it in a browser and honor the request
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string fname = (treeView1.SelectedNode.Parent.Text.ToString()).Split('\\').Last().Trim() + ".html";

                DialogResult result1 = MessageBox.Show("Open " + fname + " Results in Browser?", "CAT.Net Results", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(DestPath.Text + "\\" + fname);
                }
            }

            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        public void TraverseAndRun(string root, string binary, string rules, string dest)
        {
            label1.Text = "Enumerating .NET EXE and DLL Files...";
            label1.Refresh();
            DotNetBinary dnb = new DotNetBinary();

            try
            {

                // enumerate all .NET dll and exe files in the given directory
                var dotNetFiles = from file in Directory.EnumerateFiles(root, "*.*", SearchOption.AllDirectories)
                               where (isDotNet(file, "_CorDllMain") && file.EndsWith(".dll")) || (isDotNet(file, "_CorExeMain") && file.EndsWith(".exe"))
                               select new
                               {
                                   File = file
                               };

                label1.Text = "Enumerating Files... Complete. Found " + dotNetFiles.Count().ToString() + " files.";
                label1.Refresh();

                // only continue if we found >= 1 file
                if (dotNetFiles.Count() != 0)
                {
                    int count = 0;

                    progressBar1.Step = (int)(progressBar1.Maximum / dotNetFiles.Count());

                    // calculate the given CAT.NET timeout (how long before CAT gives up on processing a binary)
                    int timeout;
                    bool isNumeric = int.TryParse(CATtimeout.Text, out timeout);
                    if (isNumeric)
                    {
                        timeout = timeout * 1000 * 60;
                    }
                    else
                    {
                        timeout = 300000;
                    }

                    List<string> errorFiles = new List<string>();

                    foreach (var f in dotNetFiles)
                    {

                        System.IO.FileInfo fi = new System.IO.FileInfo(f.File);

                        string filePath = dest + "\\" + fi.Name;

                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = false;
                        startInfo.FileName = "\"" + binary + "\"";
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.Arguments = "/file:" + "\"" + f.File + "\"" + rules + " /report:\"" + filePath + "\"" + ".xml" + " /reportxsloutput:\"" + filePath + "\"" + ".html";

                        label1.Text = "Processing " + fi.Name + " : " + (++count).ToString() + " of " + dotNetFiles.Count().ToString();
                        label1.Refresh();

                        dnb.hash = hashFile(fi);
                        dnb.name = fi.Name;
                        dnb.application = Path.GetDirectoryName(f.File);
                                                
                        // only run CAT.NET on the binary if we haven't done so before
                        if (!DbFuncs.seenBefore(dnb))
                        {
                            try
                            {
                                // Start the process with the info we specified. Call WaitForExit and then the using statement will close.
                                using (Process exeProcess = Process.Start(startInfo))
                                {
                                    // give the process 5 minutes runtime before we kill it and move on to the next file
                                    bool cleanExit = exeProcess.WaitForExit(timeout); // default is 300000
                                    label1.Text = "Timeout reached. Moving to next file.";

                                    if (!cleanExit)
                                    {
                                        exeProcess.Kill();
                                        label1.Text = "Timout reached and process kill forced. Moving to next file.";
                                        errorFiles.Add(fi.Name);
                                    }
                                    else
                                    {
                                        label1.Text = "                                                                                                                       ";
                                        label1.Refresh();

                                        // add the file to our TreeNode                     
                                        TreeNode[] results = parseXML(filePath + ".xml");
                                        TreeNode treeNode = new TreeNode(f.File.ToString(), results);
                                        treeView1.Nodes.Add(treeNode);
                                        treeView1.Refresh();

                                        foreach (TreeNode tn in results)
                                        {
                                            string[] s = tn.Text.Split(':');
                                            Console.Write(s[0] + " " + s[1]);
                                            if (s[0].Equals("SQLi")) { int.TryParse(s[1], out dnb.numSQLi); }
                                            if (s[0].Equals("Command Execution")) { int.TryParse(s[1], out dnb.numCodEx); }
                                            if (s[0].Equals("File Canonicalisation")) { int.TryParse(s[1], out dnb.numFileEx); }
                                            if (s[0].Equals("Info Leak")) { int.TryParse(s[1], out dnb.numInfoLeak); }
                                            if (s[0].Equals("XSS")) { int.TryParse(s[1], out dnb.numXSS); }
                                            if (s[0].Equals("User Redirection")) { int.TryParse(s[1], out dnb.numRedirect); }
                                            if (s[0].Equals("XPath Injection")) { int.TryParse(s[1], out dnb.numXPath); }
                                            if (s[0].Equals("LDAP Injection")) { int.TryParse(s[1], out dnb.numLDAP); }
                                        }

                                        // add the results to the database
                                        DbFuncs.PopulateDB(dnb);
                                        // refresh the datagrid
                                        dataGridView1.DataSource = DbFuncs.DumpDB().Tables[0].DefaultView;
                                    }
                                }

                            }
                            // error either opening file or running CAT.NET on that file.
                            catch
                            {
                                errorFiles.Add(fi.Name);
                            }
                        }

                        else
                        {
                            label1.Text = "Seen this file before; moving to next file...";
                        }
                        progressBar1.PerformStep();
                        progressBar1.Refresh();
                    }
                    progressBar1.Step = progressBar1.Maximum;
                    progressBar1.PerformStep();
                    progressBar1.Refresh();
                    label1.Text = "Finished.";

                    if (errorFiles.Count > 0)
                    {
                        string errors = "There were errors processing the following files.\nTry again with a longer CAT timeout:\n" + string.Join("\n", errorFiles.ToArray());
                        MessageBox.Show(errors);
                    }
                    
                }
                
            }
            catch(Exception e)
            {
                // e.g. some sort of dir/file exception
                MessageBox.Show(e.ToString());
            }

        }

        // extract bug classes and number of bugs where > 0
        public static string getBugs(DotNetBinary dnb)
        {
            string retstring = "";
            retstring += (dnb.numCodEx > 0) ? "CodeExecution:" + dnb.numCodEx + "," : "";
            retstring += (dnb.numFileEx > 0) ? "FileCanonicalisation:" + dnb.numFileEx + "," : "";
            retstring += (dnb.numInfoLeak > 0) ? "InfoLeak:" + dnb.numInfoLeak + "," : "";
            retstring += (dnb.numLDAP > 0) ? "LDAPi:" + dnb.numLDAP + "," : "";
            retstring += (dnb.numRedirect > 0) ? "Redirect:" + dnb.numRedirect + "," : "";
            retstring += (dnb.numSQLi > 0) ? "SQLi:" + dnb.numSQLi + "," : "";
            retstring += (dnb.numXPath > 0) ? "XPathi:" + dnb.numXPath + "," : "";
            retstring += (dnb.numXSS > 0) ? "XSS:" + dnb.numXSS + "," : "";
            retstring = retstring.Substring(0, retstring.Length - 1);
            return retstring;
        }
                   
        // determines if a file is a .NET dll or exe
        // searches for the magic string _CorDllMain in DLLs
        // searches for the magic string _CorExeMain in EXEs
        private bool isDotNet(string file, string magic)
        {
            bool isDotNetBinary = false;
            int i, j;

            try
            {
                byte[] ByteBuffer = File.ReadAllBytes(file);
                byte[] StringBytes = Encoding.UTF8.GetBytes(magic);

                for (i = 0; i <= (ByteBuffer.Length - StringBytes.Length); i++)
                {
                    if (ByteBuffer[i] == StringBytes[0])
                    {
                        for (j = 1; j < StringBytes.Length && ByteBuffer[i + j] == StringBytes[j]; j++) ;
                        if (j == StringBytes.Length)
                            isDotNetBinary = true;
                    }
                }
            }
            catch(Exception e)
            {
                // e.g. cannot open file...
                MessageBox.Show(e.ToString());
            }
            return isDotNetBinary;
        }

        static TreeNode[] parseXML(string XMLfile)
        {
            var xml = XDocument.Load(@XMLfile);

            var stats = from c in xml.Root.Descendants("Rule")
                        select idMapping(c.Element("Identifier").Value) + ":" +
                               c.Element("TotalResults").Value;

            TreeNode[] results = new TreeNode[8];
            byte counter = 0;
            foreach (string result in stats)
            {
                results[counter] = new TreeNode(result);
                // if the resultset is non-zero, then change the text color to red
                if (!results[counter].Text.Contains("0")) {
                    results[counter].ForeColor = System.Drawing.Color.Red;
                }
                counter++;
            }

            return results;
        }
        
        // maps CAT.NET codes to bug class
        static string idMapping(string idreference)
        {
            switch (idreference)
            {
                case "ACESEC01":
                    return "SQLi";
                case "ACESEC02":
                    return "Command Execution";
                case "ACESEC03":
                    return "File Canonicalisation";
                case "ACESEC04":
                    return "Info Leak";
                case "ACESEC05":
                    return "XSS";
                case "ACESEC06":
                    return "User Redirection";
                case "ACESEC07":
                    return "XPath Injection";
                case "ACESEC08":
                    return "LDAP Injection";
                default:
                    return "Unkown Error";
            }
        }

        // perform SHA256 of the input .NET binary file
        static string hashFile(FileInfo f)
        {
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] hashValue;
            FileStream fileStream = f.Open(FileMode.Open);
            fileStream.Position = 0;
            hashValue = mySHA256.ComputeHash(fileStream);
            fileStream.Close();
            int i;
            string hashString = "";
            for (i = 0; i < hashValue.Length; i++)
            {
                hashString += String.Format("{0:X2}", hashValue[i]);
            }
            return hashString;
        }


        private void viewdb_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbFuncs.DumpDB().Tables[0].DefaultView;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }


    }

    // container for .NET binary file and bug info (used to write easily to db; 1:1 member:column match
    public class DotNetBinary
    {
        public string hash;                                         // primary key
        public string name;                                         // known names of the binary
        public string application;                                  // known applications that use the binary
        public int numSQLi;                                         // number of sqli bugs
        public int numCodEx;                                        // number of code execution bugs
        public int numFileEx;                                       // number of file canonicalisation bugs
        public int numInfoLeak;                                     // number of info leak bugs
        public int numXSS;                                          // number of xss bugs
        public int numRedirect;                                     // number of redirect bugs
        public int numXPath;                                        // number of XPath bugs
        public int numLDAP;                                         // number of LDAP bugs
    }

    //Container for config options
    public class MattNetConfig
    {
        public string CatNetPath;
        public string LastSrcDir;
        public string LastDstDir;
        public uint CatTimeoutMinutes;
        public bool CSQLEnabled;
        public bool CCMdExecEnabled;
        public bool CFileCanonicalisationEnabled;
        public bool CInfoDisclosureEnabled;
        public bool CXSSEnabled;
        public bool CWebRedirectEnabled;
        public bool CXPathEnabled;
        public bool CLDAPEnabled;
    }
}

