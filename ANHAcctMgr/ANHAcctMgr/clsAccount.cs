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
        public int CSR
        {
            get;
            private set;
        }

        public String Banned
        {
            get;
            private set;
        }

        public String CharsAllowed
        {
            get;
            private set;
        }
        public String LastLogin
        {
            get;
            private set;
        }

        public String Joined
        {
            get;
            private set;
        }

        public String LastCreate
        {
            get;
            private set;
        }
        public int StationID
        {
            get;
            private set;
        }
        public Account(MySqlDataReader reader)
        {
            this.Id = reader.GetInt32("account_id");
            this.UserName = reader.GetString("account_username");
            this.Email = reader.GetString("account_email");
            this.CSR = reader.GetInt32("account_csr");
            this.Banned = reader.GetString("account_banned");
            this.CharsAllowed = reader.GetString("account_characters_allowed");
            this.LastLogin = reader.GetMySqlDateTime("account_lastlogin").ToString();
            this.Joined = reader.GetMySqlDateTime("account_joindate").ToString();
            this.LastCreate = reader.GetMySqlDateTime("account_lastcreate").ToString();
            this.StationID = reader.GetInt32("account_station_id");
        }

        //public override string ToString()
        //{
        //    return String.Format("Account ({0}, {1}, {2})", this.Id, this.UserName, this.Email);
        //}

       
    }
}