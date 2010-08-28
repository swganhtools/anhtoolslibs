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
//using ANHDBI;
//using ANHDBI.MySQL;
//using Utilities;
using ANHMySQLLib;
using ANHMySQLLib.Command;
namespace ANHAcctMgr
{
    class Lists
    {
        /*******************
         * Accounts Sorted List
         *******************/
        public static SortedList<int, Account> AccountList()
        {
            //Global.Startup();
            SortedList<int, Account> lsAccounts = new SortedList<int, Account>();
            Account oAccount;

            MySqlCommand command = new MySqlCommand("swganh_utility.sp_AdminAccountList");

            command.Parameters.Add(new MySqlParameter());
            command.CommandType = System.Data.CommandType.StoredProcedure;

            AsyncMysqlQuery query = new AsyncMysqlQuery(command);

            query.SetHandler(delegate(MySqlDataReader reader)
            {
                if (query.Error == null)
                {
                    while (reader.Read())
                    {
                        oAccount = new Account(reader.GetInt32("account_id"));
                        lsAccounts.Add(oAccount.ID, oAccount);
                    }
                }
           
                else
                {
                    //Console.WriteLine("something went wrong");
                   // Console.WriteLine(query.Error.Message);
                }
            });

            Global.MysqlEngine.ExecuteAsync(query);
            return lsAccounts;
        }
    }
}
