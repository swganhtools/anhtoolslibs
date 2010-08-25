using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Utilities;

namespace ANHDBI
{
    public class MySqlLogin
    {
        private string sErrorFile = "SqlLoginErrors.txt";

        private string sUsername;
        private string sHostname;
        private string sDatabase;
        private string sPassword;
        private string sPort;
        private string sUserfile;
        private string sConnectionString;

        private DatabaseTypes oDatabaseType = DatabaseTypes.MySql;

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        public string Hostname
        {
            get { return sHostname; }
            set { sHostname = value; }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string Username
        {
            get { return sUsername; }
            set { sUsername = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get { return sPassword; }
            set { sPassword = value; }
        }


        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get
            {
                BuildConnectionString();
                return sConnectionString;
            }
        }
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        public string Database
        {
            get { return sDatabase; }
            set { sDatabase = value; }
        }


        /// <summary>
        /// Gets or sets the server port.
        /// </summary>
        /// <value>The server port.</value>
        public string Port
        {
            get { return sPort; }
            set { sPort = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SqlLogin"/> class.
        /// </summary>
        public MySqlLogin()
        {
            oDatabaseType = DatabaseTypes.MySql;

            sUsername = "";
            sHostname = "";
            sDatabase = "";
            sPassword = "";
            sPort = "3306";                 // TCP 3306 is MySQL Server Default Port

            sUserfile = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SqlLogin"/> class.
        /// </summary>
        /// <param name="DatabaseType">Type of the database.</param>
        public MySqlLogin(DatabaseTypes DatabaseType)
        {
            oDatabaseType = DatabaseType;

            sUsername = "";
            sHostname = "";
            sDatabase = "";
            sPassword = "";
            sPort = "3306";                 // TCP 3306 is MySQL Server Default Port

            sUserfile = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SqlLogin"/> class.
        /// </summary>
        /// <param name="DatabaseType">Type of the database.</param>
        /// <param name="Filename">The filename.</param>
        public MySqlLogin(DatabaseTypes DatabaseType, string Filename)
        {
            oDatabaseType = DatabaseType;

            sUserfile = Filename;

            sUsername = "";
            sHostname = "";
            sDatabase = "";
            sPassword = "";
            sPort = "3306";                 // TCP 3306 is MySQL Server Default Port
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SqlLogin"/> class.
        /// </summary>
        /// <param name="DatabaseType">Type of the database.</param>
        /// <param name="Hostname">The hostname.</param>
        /// <param name="Username">The username.</param>
        /// <param name="Password">The password.</param>
        /// <param name="Database">The database.</param>
        /// <param name="Port">The port.</param>
        public MySqlLogin(DatabaseTypes DatabaseType, string Hostname, string Username, string Password, string Database, string Port)
        {
            oDatabaseType = DatabaseType;

            sHostname = Hostname;
            sUsername = Username;
            sPassword = Password;
            sDatabase = Database;

            if (int.Parse(Port) > 0)
                sPort = Port;
            else
                sPort = "3306";             // TCP 3306 is MySQL Server Default Port

            sUserfile = "";

            BuildConnectionString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SqlLogin"/> class.
        /// </summary>
        /// <param name="DatabaseType">Type of the database.</param>
        /// <param name="Hostname">The hostname.</param>
        /// <param name="Username">The username.</param>
        /// <param name="Password">The password.</param>
        /// <param name="Database">The database.</param>
        /// <param name="Port">The port.</param>
        /// <param name="Filename">The filename.</param>
        public MySqlLogin(DatabaseTypes DatabaseType, string Hostname, string Username, string Password, string Database, string Port, string Filename)
        {
            oDatabaseType = DatabaseType;

            sHostname = Hostname;
            sUsername = Username;
            sPassword = Password;
            sDatabase = Database;

            if (int.Parse(Port) > 0)
                sPort = Port;
            else
                sPort = "3306";             // TCP 3306 is MySQL Server Default Port

            sUserfile = Filename;

            BuildConnectionString();
        }

        /// <summary>
        /// Saves sql Login information.
        /// </summary>
        public void Save()
        {
            if (sUserfile != "")
            {
                XmlSerializer xSerializer = new XmlSerializer(typeof(MySqlLogin));
                TextWriter oWriter = new StreamWriter(sUserfile);
                xSerializer.Serialize(oWriter, this);
            }
        }

        /// <summary>
        /// Saves the sql Login information to the specified filename.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        public void Save(string Filename)
        {

            if (Filename != "")
            {
                sUserfile = Filename;
            }

            if (sUserfile != "")
            {
                XmlSerializer xSerializer = new XmlSerializer(typeof(MySqlLogin));
                TextWriter oWriter = new StreamWriter(sUserfile);
                xSerializer.Serialize(oWriter, this);
            }
        }

        /// <summary>
        /// Loads the Sql Login information from the specified file.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public bool Load(string Filename)
        {
            bool bResult = false;

            if (Filename != "")
            {
                sUserfile = Filename;
            }

            if (File.Exists(Filename))
            {
                XmlSerializer xSerializer = new XmlSerializer(typeof(MySqlLogin));
                FileStream fsStream = null;

                try
                {
                    fsStream = new FileStream(sUserfile, FileMode.Open);

                    if (fsStream != null)
                    {
                        XmlReader xReader = new XmlTextReader(fsStream);

                        if (xReader != null)
                        {
                            MySqlLogin sqlLogin = xSerializer.Deserialize(xReader) as MySqlLogin;

                            if (sqlLogin != null)
                            {
                                sUsername = sqlLogin.Username;
                                sHostname = sqlLogin.Hostname;
                                sPort = sqlLogin.Port;
                                sDatabase = sqlLogin.Database;
                                sPassword = sqlLogin.Password;
                            }
                        }//if (xReader != null)
                    }//if (fsStream != null)
                }//try
                catch (Exception ex)
                {
                    Log.WriteLine(ex.Message, sErrorFile, true);
                }//catch
                finally
                {
                    if (fsStream != null)
                    {
                        fsStream.Close();
                    }
                }

                bResult = true;
            }

            return bResult;
        }

        /// <summary>
        /// Builds the connection string.
        /// </summary>
        private void BuildConnectionString()
        {
            //MySql Connection String - Database=[DBNAME];Data Source=[HOSTNAME]:[PORT];User Id=[USERNAME];Password=[PASSWORD]
            //SqlServer Connection String - Initial Catalog=[DBNAME];Data Source=[HOSTNAME]:[PORT];User Id=[USERNAME];Password=[PASSWORD]
            //SqlServer Windows Auth - Initial Catalog=[DBNAME];data source=[HOSTNAME]:[PORT];Integrated Security=SSPI;            

            //Check the type of Database and use proper syntax
            if (oDatabaseType == DatabaseTypes.SqlServer)
                sConnectionString = "Initial Catalog=";
            else if (oDatabaseType == DatabaseTypes.MySql)
                sConnectionString = "Database=";

            sConnectionString += sDatabase + ";";
            sConnectionString += "Data Source=" + sHostname;

            if (sPort != "")
                sConnectionString += /*":" + sPort +*/ ";";
            else
                sConnectionString += ";";

            //Check if Windows Authentication is selected
            if (oDatabaseType == DatabaseTypes.SqlServer && sUsername == "" && sPassword == "")
            {
                sConnectionString += "Integrated Security=SSPI";
            }
            else
            {
                sConnectionString += "User Id=" + sUsername + ";";
                sConnectionString += "Password=" + sPassword + ";";
            }

        }
    }//class
}
