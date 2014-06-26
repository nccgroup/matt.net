/*
 * Released as open source by NCC Group Plc - http://www.nccgroup.com/
 * 
 * Developed by Matt Lewis, (matt [dot] lewis [at] nccgroup.com)
 * 
 * http://www.github.com/nccgroup/matt.net
 * 
 * Released under AGPL. See LICENSE for more information
 */

namespace MattDotNetGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CB_CommandExecution = new System.Windows.Forms.CheckBox();
            this.CB_FileCanonicalisation = new System.Windows.Forms.CheckBox();
            this.CB_InformationDisclosure = new System.Windows.Forms.CheckBox();
            this.CB_LDAPInjection = new System.Windows.Forms.CheckBox();
            this.CB_XPathInjection = new System.Windows.Forms.CheckBox();
            this.CB_SQLInjection = new System.Windows.Forms.CheckBox();
            this.CB_WebRedirection = new System.Windows.Forms.CheckBox();
            this.CB_XSS = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.GoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.SourceButton = new System.Windows.Forms.Button();
            this.CatNETButton = new System.Windows.Forms.Button();
            this.CatNETPath = new System.Windows.Forms.TextBox();
            this.DestPath = new System.Windows.Forms.TextBox();
            this.DestButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.viewdb = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CATtimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_CommandExecution
            // 
            this.CB_CommandExecution.AutoSize = true;
            this.CB_CommandExecution.Checked = true;
            this.CB_CommandExecution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_CommandExecution.Location = new System.Drawing.Point(25, 48);
            this.CB_CommandExecution.Name = "CB_CommandExecution";
            this.CB_CommandExecution.Size = new System.Drawing.Size(123, 17);
            this.CB_CommandExecution.TabIndex = 1;
            this.CB_CommandExecution.Text = "Command Execution";
            this.CB_CommandExecution.UseVisualStyleBackColor = true;
            // 
            // CB_FileCanonicalisation
            // 
            this.CB_FileCanonicalisation.AutoSize = true;
            this.CB_FileCanonicalisation.Checked = true;
            this.CB_FileCanonicalisation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_FileCanonicalisation.Location = new System.Drawing.Point(25, 71);
            this.CB_FileCanonicalisation.Name = "CB_FileCanonicalisation";
            this.CB_FileCanonicalisation.Size = new System.Drawing.Size(122, 17);
            this.CB_FileCanonicalisation.TabIndex = 2;
            this.CB_FileCanonicalisation.Text = "File Canonicalisation";
            this.CB_FileCanonicalisation.UseVisualStyleBackColor = true;
            // 
            // CB_InformationDisclosure
            // 
            this.CB_InformationDisclosure.AutoSize = true;
            this.CB_InformationDisclosure.Checked = true;
            this.CB_InformationDisclosure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_InformationDisclosure.Location = new System.Drawing.Point(25, 94);
            this.CB_InformationDisclosure.Name = "CB_InformationDisclosure";
            this.CB_InformationDisclosure.Size = new System.Drawing.Size(130, 17);
            this.CB_InformationDisclosure.TabIndex = 3;
            this.CB_InformationDisclosure.Text = "Information Disclosure";
            this.CB_InformationDisclosure.UseVisualStyleBackColor = true;
            // 
            // CB_LDAPInjection
            // 
            this.CB_LDAPInjection.AutoSize = true;
            this.CB_LDAPInjection.Checked = true;
            this.CB_LDAPInjection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_LDAPInjection.Location = new System.Drawing.Point(25, 186);
            this.CB_LDAPInjection.Name = "CB_LDAPInjection";
            this.CB_LDAPInjection.Size = new System.Drawing.Size(97, 17);
            this.CB_LDAPInjection.TabIndex = 4;
            this.CB_LDAPInjection.Text = "LDAP Injection";
            this.CB_LDAPInjection.UseVisualStyleBackColor = true;
            // 
            // CB_XPathInjection
            // 
            this.CB_XPathInjection.AutoSize = true;
            this.CB_XPathInjection.Checked = true;
            this.CB_XPathInjection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_XPathInjection.Location = new System.Drawing.Point(25, 163);
            this.CB_XPathInjection.Name = "CB_XPathInjection";
            this.CB_XPathInjection.Size = new System.Drawing.Size(98, 17);
            this.CB_XPathInjection.TabIndex = 5;
            this.CB_XPathInjection.Text = "XPath Injection";
            this.CB_XPathInjection.UseVisualStyleBackColor = true;
            // 
            // CB_SQLInjection
            // 
            this.CB_SQLInjection.AutoSize = true;
            this.CB_SQLInjection.Checked = true;
            this.CB_SQLInjection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_SQLInjection.Location = new System.Drawing.Point(25, 25);
            this.CB_SQLInjection.Name = "CB_SQLInjection";
            this.CB_SQLInjection.Size = new System.Drawing.Size(90, 17);
            this.CB_SQLInjection.TabIndex = 6;
            this.CB_SQLInjection.Text = "SQL Injection";
            this.CB_SQLInjection.UseVisualStyleBackColor = true;
            // 
            // CB_WebRedirection
            // 
            this.CB_WebRedirection.AutoSize = true;
            this.CB_WebRedirection.Checked = true;
            this.CB_WebRedirection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_WebRedirection.Location = new System.Drawing.Point(25, 140);
            this.CB_WebRedirection.Name = "CB_WebRedirection";
            this.CB_WebRedirection.Size = new System.Drawing.Size(106, 17);
            this.CB_WebRedirection.TabIndex = 7;
            this.CB_WebRedirection.Text = "Web Redirection";
            this.CB_WebRedirection.UseVisualStyleBackColor = true;
            // 
            // CB_XSS
            // 
            this.CB_XSS.AutoSize = true;
            this.CB_XSS.Checked = true;
            this.CB_XSS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_XSS.Location = new System.Drawing.Point(25, 117);
            this.CB_XSS.Name = "CB_XSS";
            this.CB_XSS.Size = new System.Drawing.Size(147, 17);
            this.CB_XSS.TabIndex = 8;
            this.CB_XSS.Text = "Cross-Site Scripting (XSS)";
            this.CB_XSS.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_XPathInjection);
            this.groupBox1.Controls.Add(this.CB_LDAPInjection);
            this.groupBox1.Controls.Add(this.CB_InformationDisclosure);
            this.groupBox1.Controls.Add(this.CB_FileCanonicalisation);
            this.groupBox1.Controls.Add(this.CB_CommandExecution);
            this.groupBox1.Controls.Add(this.CB_XSS);
            this.groupBox1.Controls.Add(this.CB_SQLInjection);
            this.groupBox1.Controls.Add(this.CB_WebRedirection);
            this.groupBox1.Location = new System.Drawing.Point(28, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 221);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bug Classes";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Maroon;
            this.progressBar1.Location = new System.Drawing.Point(28, 607);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1006, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(28, 380);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(194, 23);
            this.GoButton.TabIndex = 11;
            this.GoButton.Text = "Find Some Bugs...";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 633);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 12;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Source Folder";
            // 
            // SourcePath
            // 
            this.SourcePath.Location = new System.Drawing.Point(25, 74);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(669, 20);
            this.SourcePath.TabIndex = 13;
            // 
            // SourceButton
            // 
            this.SourceButton.Location = new System.Drawing.Point(701, 71);
            this.SourceButton.Name = "SourceButton";
            this.SourceButton.Size = new System.Drawing.Size(75, 23);
            this.SourceButton.TabIndex = 14;
            this.SourceButton.Text = "Source Dir";
            this.SourceButton.UseVisualStyleBackColor = true;
            this.SourceButton.Click += new System.EventHandler(this.SourceButton_Click);
            // 
            // CatNETButton
            // 
            this.CatNETButton.Location = new System.Drawing.Point(701, 33);
            this.CatNETButton.Name = "CatNETButton";
            this.CatNETButton.Size = new System.Drawing.Size(75, 23);
            this.CatNETButton.TabIndex = 16;
            this.CatNETButton.Text = "Cat.NET";
            this.CatNETButton.UseVisualStyleBackColor = true;
            this.CatNETButton.Click += new System.EventHandler(this.CatNETButton_Click);
            // 
            // CatNETPath
            // 
            this.CatNETPath.Location = new System.Drawing.Point(25, 36);
            this.CatNETPath.Name = "CatNETPath";
            this.CatNETPath.Size = new System.Drawing.Size(669, 20);
            this.CatNETPath.TabIndex = 15;
            // 
            // DestPath
            // 
            this.DestPath.Location = new System.Drawing.Point(26, 113);
            this.DestPath.Name = "DestPath";
            this.DestPath.Size = new System.Drawing.Size(669, 20);
            this.DestPath.TabIndex = 18;
            // 
            // DestButton
            // 
            this.DestButton.Location = new System.Drawing.Point(701, 111);
            this.DestButton.Name = "DestButton";
            this.DestButton.Size = new System.Drawing.Size(75, 23);
            this.DestButton.TabIndex = 19;
            this.DestButton.Text = "Dest Dir";
            this.DestButton.UseVisualStyleBackColor = true;
            this.DestButton.Click += new System.EventHandler(this.DestButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(241, 153);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(793, 292);
            this.treeView1.TabIndex = 20;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 451);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1006, 150);
            this.dataGridView1.TabIndex = 21;
            // 
            // viewdb
            // 
            this.viewdb.Location = new System.Drawing.Point(28, 422);
            this.viewdb.Name = "viewdb";
            this.viewdb.Size = new System.Drawing.Size(194, 23);
            this.viewdb.TabIndex = 22;
            this.viewdb.Text = "View Database";
            this.viewdb.UseVisualStyleBackColor = true;
            this.viewdb.Click += new System.EventHandler(this.viewdb_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(959, 124);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 23;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MattDotNetGUI.Properties.Resources.image001;
            this.pictureBox1.Location = new System.Drawing.Point(830, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 78);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CATtimeout
            // 
            this.CATtimeout.Location = new System.Drawing.Point(830, 127);
            this.CATtimeout.Name = "CATtimeout";
            this.CATtimeout.Size = new System.Drawing.Size(100, 20);
            this.CATtimeout.TabIndex = 24;
            this.CATtimeout.Text = "5";
            this.CATtimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(827, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "CAT Timeout (min)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1066, 665);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CATtimeout);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.viewdb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.DestButton);
            this.Controls.Add(this.DestPath);
            this.Controls.Add(this.CatNETButton);
            this.Controls.Add(this.CatNETPath);
            this.Controls.Add(this.SourceButton);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matt.NET";
            this.TransparencyKey = System.Drawing.SystemColors.WindowFrame;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox CB_CommandExecution;
        private System.Windows.Forms.CheckBox CB_FileCanonicalisation;
        private System.Windows.Forms.CheckBox CB_InformationDisclosure;
        private System.Windows.Forms.CheckBox CB_LDAPInjection;
        private System.Windows.Forms.CheckBox CB_XPathInjection;
        private System.Windows.Forms.CheckBox CB_SQLInjection;
        private System.Windows.Forms.CheckBox CB_WebRedirection;
        private System.Windows.Forms.CheckBox CB_XSS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.Button SourceButton;
        private System.Windows.Forms.Button CatNETButton;
        private System.Windows.Forms.TextBox CatNETPath;
        private System.Windows.Forms.TextBox DestPath;
        private System.Windows.Forms.Button DestButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button viewdb;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.TextBox CATtimeout;
        private System.Windows.Forms.Label label2;
    }
}

