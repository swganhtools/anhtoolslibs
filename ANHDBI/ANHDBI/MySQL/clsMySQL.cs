using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Utilities;

namespace ANHDBI.MySQL
{
    public class MySQLRunner
    {
        private static string sErrorFile = "MySqlErrors.txt";
        private static string sConnectionString = "";

        public static string ConnectionString
        {
            get { return sConnectionString; }
            set { sConnectionString = value; }
        }

        public static string ErrorFile
        {
            get { return sErrorFile; }
            set { sErrorFile = value; }
        }

        static public bool ExecuteQuery(string SQL, MySqlConnection Connection, ref MySqlDataReader RecordSet)
        {
            MySqlCommand cmdGet = new MySqlCommand(SQL, Connection);

            try
            {
                cmdGet.Connection.Open();
                RecordSet = cmdGet.ExecuteReader();
            }
            catch (DataException dEx)
            {
                Log.WriteLine(dEx.Message, sErrorFile, true);
                return false;
            }
            catch (MySqlException mEx)
            {
                Log.WriteLine(mEx.Message, sErrorFile, true);
                return false;
            }
            catch (Exception ex)
            {
                Log.WriteLine(ex.Message, sErrorFile, true);
                return false;
            }

            return true;
        }

        static public bool ExecuteNonQuery(string SQL, MySqlConnection Connection)
        {
            MySqlCommand cmdExecute = new MySqlCommand(SQL, Connection);

            try
            {
                cmdExecute.Connection.Open();
                cmdExecute.ExecuteNonQuery();
            }
            catch (DataException dEx)
            {
                Log.WriteLine(dEx.Message, sErrorFile, true);
                return false;
            }
            catch (MySqlException mEx)
            {
                Log.WriteLine(mEx.Message, sErrorFile, true);
                return false;
            }
            catch (Exception ex)
            {
                Log.WriteLine(ex.Message, sErrorFile, true);
                return false;
            }

            return true;
        }
    }//class
}

