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
using ANHMySQLLib;
using ANHMySQLLib.Command;


namespace ANHAcctMgr
{
    class Lists
    {
        /*******************
         * Accounts Sorted List
         *******************/
        public static List<Account> GetAllAccounts()
        {

            // Sync query example. Bad bad bad, dont use it 
       
            List<Account> accounts = new List<Account>();

            
            AsyncMysqlQuery query = new AsyncMysqlQuery("CALL swganh_utility.sp_AdminAccountList();");

            query.SetHandler(delegate(MySqlDataReader reader)
            {
                if (query.Error == null)
                {
                    while (reader.Read())
                    {
                        Account account = new Account(reader);                        
                        accounts.Add(account);
                    }
                }
                else
                {
                    Console.WriteLine("something went wrong");
                }


            });

            Database.Utility.ExecuteSync(query);
            return accounts;
            
        }

    }
}
