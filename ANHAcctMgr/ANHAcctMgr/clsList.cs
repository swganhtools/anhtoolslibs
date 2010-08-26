using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Configuration;
using MySql.Data.MySqlClient;
using ANHDBI;
using ANHDBI.MySQL;
using Utilities;

namespace ANHAcctMgr
{
    class Lists
    {
        /*******************
         * Accounts Sorted List
         *******************/
        public static SortedList<int, Account> AccountList()
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            SortedList<int, Account> lsAccounts = new SortedList<int, Account>();
            MySqlConnection conGet = new MySqlConnection(MySQLRunner.ConnectionString);
            MySqlDataReader drGet = null;
            string sSQL = "";
            Account oAccount;

            sSQL = "SELECT account_id FROM account";

            if (MySQLRunner.ExecuteQuery(sSQL, conGet, ref drGet) == true)
            {

                while (drGet.Read())
                {
                    oAccount = new Account(drGet.GetInt32(drGet.GetOrdinal("account_id")));
                    lsAccounts.Add(oAccount.ID, oAccount);
                }
            }
            else
            {
                MessageBox.Show("Error connecting to the database.");
            }

            if (conGet.State == ConnectionState.Open)
            {
                if (drGet != null)
                    drGet.Close();

                conGet.Close();
            }
            return lsAccounts;
        }
    }
}
