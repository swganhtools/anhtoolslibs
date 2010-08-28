using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANHMySQLLib;
using ANHMySQLLib.Command;

namespace ANHAcctMgr
{
    public class Global
    {
        private static MysqlEngine mMysqlEngine;

        public static MysqlEngine MysqlEngine
        {
            get
            {
                return mMysqlEngine;
            }
        }

        public static void Startup()
        {
            mMysqlEngine = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["utilityhost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["utilityuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["utilitypassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["utilitydatabase"] + ";");
            mMysqlEngine.AddConnections(2);


        }

        public static void Shutdown()
        {
            mMysqlEngine.Shutdown(false);

        }
    }
}
