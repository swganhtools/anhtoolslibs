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

namespace ANHAcctMgr
{
    class Account
    {
        private string sUsername;
        private string sEmail;
        private int sCSR;
        private string sCharsAllowed;
        private string sLastLogin;
        private string sBanned;
        private string sJoinDate;
        private string sActive;
        private string sSessionKey;
        private string sLoggedIn;
        private string sLastCreate;
        private string sAuthenticated;
        private int nStationID;
        private int nID;
        private bool flgIsNew = false;
        private bool flgDeleted = false;

        private static int nMAXID = 0;
        private static int nMAXStationID = 0;
        public string Username
        {
            get { return sUsername; }
            set { sUsername = value; }
        }
        
        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public int CSR
        {
            get { return sCSR; }
            set { sCSR = value; }
        }
        public string Banned
        {
            get { return sBanned; }
            set { sBanned = value; }
        }
        public string CharsAllowed
        {
            get { return sCharsAllowed; }
            set { sCharsAllowed = value; }
        }
        public string LastLogin
        {
            get { return sLastLogin; }
            set { sLastLogin = value; }
        }
        public string LastCreate
        {
            get { return sLastCreate; }
            set { sLastCreate = value; }
        }
        public string JoinDate
        {
            get { return sJoinDate; }
            set { sJoinDate = value; }
        }
        public string Active
        {
            get { return sActive; }
            set { sActive = value; }
        }
        public string SessionKey
        {
            get { return sSessionKey; }
            set { sSessionKey = value; }
        }
        public string LoggedIn
        {
            get { return sLoggedIn; }
            set { sLoggedIn = value; }
        }
        public string Authenticated
        {
            get { return sAuthenticated; }
            set { sAuthenticated = value; }
        }
        public int ID
        {
            get { return nID; }
            set { nID = value; }
        }
        public int StationID
        {
            get { return nStationID; }
            set { nStationID = value; }
        }
        public bool IsNew
        {
            get { return flgIsNew; }
        }


        public Account()
        {
            if (nMAXID == 0)
                nMAXID = GetMaxID();
            if (nMAXStationID == 0)
                nMAXStationID = GetMaxStationID();
            nMAXID++;
            nMAXStationID++;

           sUsername = "";
           sEmail = "";
           sCSR = 0;
           sCharsAllowed = "";
           sLastLogin = "";
           sBanned = "";
           sJoinDate = "";
           sActive = "";
           sSessionKey = "";
           sLoggedIn = "";
           sLastCreate = "";
            nID = nMAXID;
            nStationID = nMAXStationID;
            flgIsNew = true;
        }

        public Account(int ID)
        {
            MySQLRunner.ConnectionString = clsDBStrings.toolsdbcon;
            MySqlConnection conGet = new MySqlConnection(MySQLRunner.ConnectionString);
            MySqlDataReader drGet = null;
            string sSQL = "";

            sSQL = "CALL sp_AdminAccountData('" + ID.ToString() + "');";

            if (MySQLRunner.ExecuteQuery(sSQL, conGet, ref drGet) == true)
            {
                drGet.Read();

                if (drGet.HasRows == false)
                {
                    if (nMAXID == 0)
                        nMAXID = GetMaxID();
                    if (nMAXStationID == 0)
                        nMAXStationID = GetMaxStationID();

                    sUsername = "";
                    sEmail = "";
                    sCSR = 0;
                    sCharsAllowed = "";
                    sLastLogin = "";
                    sBanned = "";
                    sJoinDate = "";
                    sActive = "";
                    sSessionKey = "";
                    sLoggedIn = "";
                    sLastCreate = "";
                    nID = 0;
                    nStationID = 0;

                    flgIsNew = true;
                }
                else
                {
                    sUsername = drGet.GetString(drGet.GetOrdinal("account_username"));
                    sEmail = drGet.GetString(drGet.GetOrdinal("account_email"));                    
                    sCSR = drGet.GetInt32("account_csr");
                    sCharsAllowed = drGet.GetString(drGet.GetOrdinal("account_characters_allowed"));
                    sLastLogin = drGet.GetMySqlDateTime("account_lastlogin").ToString();
                    sBanned = drGet.GetString(drGet.GetOrdinal("account_banned"));
                    sJoinDate = drGet.GetMySqlDateTime("account_joindate").ToString();
                    sActive = drGet.GetString(drGet.GetOrdinal("account_active"));
                    //if (string.IsNullOrEmpty(drGet.GetString(drGet.GetOrdinal("account_session_key"))))
                    //{
                    //    sSessionKey = "";
                    //}
                    //else
                    //{
                    //    sSessionKey = drGet.GetString(drGet.GetOrdinal("account_session_key"));
                    //}
                    sLoggedIn = drGet.GetString(drGet.GetOrdinal("account_loggedin"));
                    sLastCreate = drGet.GetMySqlDateTime("account_lastcreate").ToString();
                    sAuthenticated = drGet.GetString(drGet.GetOrdinal("account_authenticated"));
                    nID = ID;
                    nStationID = StationID;
                    flgIsNew = false;
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
        }

        public void Delete()
        {
            flgDeleted = true;
        }

        public bool Save()
        {
            bool flgReturn;

            if (flgDeleted == false)
            {
                if (flgIsNew == true)
                    flgReturn = Add();
                else
                    flgReturn = Update();
            }
            else
            {
                flgReturn = DeleteObject();
            }

            if (flgReturn == true)
                flgIsNew = false;

            return flgReturn;
        }

        private bool Update()
        {
            MySQLRunner.ConnectionString = clsDBStrings.utilitydbcon;
            MySqlConnection conUpdate = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            bool flgReturn = false;
            sSQL = "CALL sp_AdminAccountUpdate('" + nID.ToString() + "','" + sUsername + "','" + nStationID + "', '" + sCSR + "', '" + sEmail + "','" + sBanned + "','" + sCharsAllowed + "');";
           
            if (MySQLRunner.ExecuteNonQuery(sSQL, conUpdate) == false)
                flgReturn = false;
            else
                flgReturn = true;

            if (conUpdate.State == ConnectionState.Open)
            {
                conUpdate.Close();
            }
            return flgReturn;
        }

        private bool Add()
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            bool flgReturn = false;

            //sSQL = "INSERT into clients (first_name, last_name, street_address, city, state, zip, phone, email, comments) VALUES ( " +
            //       "'" + sFirstName + "', " +
            //       "'" + sLastName + "', " +
            //       "'" + sAddress + "', " +
            //       "'" + sCity + "', " +
            //       "'" + sState + "', " +
            //       "'" + sZip + "', " +
            //       "'" + sPhone + "', " +
            //       "'" + sEmail + "', " +
            //       "'" + sComments + "');";


            if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
                flgReturn = false;
            else
                flgReturn = true;

            if (conAdd.State == ConnectionState.Open)
            {
                conAdd.Close();
            }

            return flgReturn;
        }

        public bool DeleteObject()
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            MySqlConnection conDelete = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            bool flgReturn = false;

            sSQL = "DELETE FROM account WHERE account_id=" + nID.ToString();

            if (MySQLRunner.ExecuteNonQuery(sSQL, conDelete) == false)
                flgReturn = false;
            else
                flgReturn = true;

            if (conDelete.State == ConnectionState.Open)
            {
                conDelete.Close();
            }

            return flgReturn;
        }

        private int GetMaxID()
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            MySqlConnection conGet = new MySqlConnection(MySQLRunner.ConnectionString);
            MySqlDataReader drGet = null;
            string sSQL = "";
            int nMax = 0;

            sSQL = "select MAX(account_id) AS ID from account";

            if (MySQLRunner.ExecuteQuery(sSQL, conGet, ref drGet) == true)
            {
                drGet.Read();

                if (drGet.HasRows == false)
                {
                    nMax = 0;
                }
                else
                {
                    nMax = drGet.GetInt32(drGet.GetOrdinal("ID"));
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

            return nMax;
        }
        private int GetMaxStationID()
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            MySqlConnection conGet = new MySqlConnection(MySQLRunner.ConnectionString);
            MySqlDataReader drGet = null;
            string sSQL = "";
            int nMax = 0;

            sSQL = "SELECT MAX(account_station_id) AS StationID FROM account";

            if (MySQLRunner.ExecuteQuery(sSQL, conGet, ref drGet) == true)
            {
                drGet.Read();

                if (drGet.HasRows == false)
                {
                    nMax = 0;
                }
                else
                {
                    nMax = drGet.GetInt32(drGet.GetOrdinal("StationID"));
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

            return nMax;
        }
    }
}