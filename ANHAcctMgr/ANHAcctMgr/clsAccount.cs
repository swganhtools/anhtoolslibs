using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ANHDBI;
using ANHDBI.MySQL;
using Utilities;
using ANHMySQLLib;
using ANHMySQLLib.Command;
namespace ANHAcctMgr
{
    class Account
    {
        public int Id
        {
            get;
            private set;
        }

        public String UserName
        {
            get;
            private set;
        }

        public String Email
        {
            get;
            private set;
        }


        public Account(MySqlDataReader reader)
        {
            this.Id = reader.GetInt32("account_id");
            this.UserName = reader.GetString("account_username");
            this.Email = reader.GetString("account_email");

        }

        public override string ToString()
        {
            return String.Format("Account ({0}, {1}, {2})", this.Id, this.UserName, this.Email);
        }

        public static List<Account> GetAllAccounts()
        {
            Global.Startup();
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

            Global.MysqlEngine.ExecuteSync(query);

            return accounts;
        }
    }
}