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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

// Ideally should use prepared statements in this module

namespace MattDotNetGUI
{
    class DbFuncs
    {
        private static string dbFile = "MattDotNet.sqlite";
        private static string dbName = "dotnetbinaries";

        private static SQLiteConnection m_dbConnection;
        private static SQLiteCommand command;
        private static DataSet ds = new DataSet();
        private static DataTable dt = new DataTable();

        private static void SetConnection()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
        }

        private static void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            m_dbConnection.Open();
            command = m_dbConnection.CreateCommand();
            command.CommandText = txtQuery;
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        public static void CreateDB()
        {
            try
            {
                SQLiteConnection.CreateFile(dbFile);
                string sql = "create table " + dbName + " (name varchar(128), application varchar(256), hash varchar(64), numSQLi int, numCodEx int, numFileEx int, numInfoLeak int, numXSS int, numRedirect int, numXPath int, numLDAP int)";
                ExecuteQuery(sql);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public static void PopulateDB(DotNetBinary dnb)
        {
            try
            {
                SetConnection();
                m_dbConnection.Open();
              
                string sql = "SELECT * FROM " + dbName + " WHERE hash = '" + dnb.hash + "' AND application = '" + dnb.application + "';";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                // check if we've seen this file before (in terms of hash and file location). If not, add it to the db
                if (!reader.HasRows)
                {
                    sql = "INSERT into " + dbName + " (name, application, hash, numSQLi, numCodEx, numFileEx, numInfoLeak, numXSS, numRedirect, numXPath, numLDAP) values ('" + dnb.name + "','" + dnb.application + "','" + dnb.hash + "'," + dnb.numSQLi + "," + dnb.numCodEx + "," + dnb.numFileEx + "," + dnb.numInfoLeak + "," + dnb.numXSS + "," + dnb.numRedirect + "," + dnb.numXPath + "," + dnb.numLDAP + ")";                         
                    ExecuteQuery(sql);
                }
              
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }

        }

        public static bool seenBefore(DotNetBinary dnb)
        {
                SetConnection();
                m_dbConnection.Open();
                string sql = "SELECT * FROM " + dbName + " WHERE hash = '" + dnb.hash + "' AND application = '" + dnb.application + "';";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                return reader.HasRows;
        }

        public static DataSet DumpDB()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source="+dbFile+";Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * from " + dbName;
            
            DataSet ds = new DataSet();
            var da = new SQLiteDataAdapter(sql, m_dbConnection);
            da.Fill(ds);
            m_dbConnection.Close();
            return ds;          
        }
    }
}
