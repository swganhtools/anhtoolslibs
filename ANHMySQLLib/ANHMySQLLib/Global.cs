using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANHMySQLLib
{
    public class Global
    {
     private static MysqlEngine mMainDB;
        private static MysqlEngine mConfigDB;
        private static MysqlEngine mLogDB;
        private static MysqlEngine mAstromechDB;
        private static MysqlEngine mToolsDB;
        private static MysqlEngine mUtilityDB;
        private static MysqlEngine mArchiveDB;
        public static MysqlEngine MysqlEngine
        {
            get
            {
                return mMainDB;
                return mConfigDB;
                return mLogDB;
                return mAstromechDB;
                return mToolsDB;
                return mUtilityDB;
            }
        }

        public static void Startup()
        {
            mMainDB = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["mainhost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["mainuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["mainpassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["maindatabase"] + ";");
            mMainDB.AddConnections(3);

            mConfigDB = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["confighost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["configuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["configpassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["configdatabase"] + "");
            mConfigDB.AddConnections(3);

            mLogDB = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["loghost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["loguser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["logpassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["logdatabase"] + "");
            mLogDB.AddConnections(3);

            mAstromechDB = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["astromechhost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["astromechuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["astromechpassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["astromechdatabase"] + "");
            mAstromechDB.AddConnections(3);

            mArchiveDB = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["archivehost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["archiveuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["archivepassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["archivedatabase"] + "");
            mAstromechDB.AddConnections(3);

            mToolsDB = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["toolshost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["toolsuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["toolspassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["toolsdatabase"] + "");
            mToolsDB.AddConnections(3);

            mUtilityDB = new MysqlEngine("Address=" + System.Configuration.ConfigurationManager.AppSettings["utilityhost"] + ";Username=" + System.Configuration.ConfigurationManager.AppSettings["utilityuser"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["utilitypassword"] + ";database=" + System.Configuration.ConfigurationManager.AppSettings["utilitydatabase"] + "");
            mUtilityDB.AddConnections(3);

        }

        public static void Shutdown()
        {
            mMainDB.Shutdown(false);
            mConfigDB.Shutdown(false);
            mLogDB.Shutdown(false);
            mAstromechDB.Shutdown(false);
            mToolsDB.Shutdown(false);
            mUtilityDB.Shutdown(false);
            mArchiveDB.Shutdown(false);
        }
    }
}
