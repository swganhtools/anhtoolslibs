using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANHMySQLLib;

namespace ANHAcctMgr
{
    class Database
    {
        private static MysqlEngine mUtilityDb;

        public static MysqlEngine Utility
        {
            get
            {
                return mUtilityDb;
            }
        }

        public static void Startup()
        {
            mUtilityDb = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["utilityhost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["utilityuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["utilitypassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["utilitydatabase"] + ";");
            mUtilityDb.AddConnections(2);
         

        }

        public static void Shutdown()
        {
            mUtilityDb.Shutdown(false);
        }
    }
}
