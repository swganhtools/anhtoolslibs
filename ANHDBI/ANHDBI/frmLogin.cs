using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ANHDBI
{
    public partial class frmLogin : Form
    {
        private string sConnectionString = "";
        private DatabaseTypes oDatabaseType;

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get { return sConnectionString; }
            set { sConnectionString = value; }
        }

        /// <summary>
        /// Gets the type of the database.
        /// </summary>
        /// <value>The type of the database.</value>
        public DatabaseTypes DatabaseType
        {
            get { return oDatabaseType; }
        }

        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        /// <value>The hostname.</value>
        public string Hostname
        {
            get { return txtHostname.Text; }
            set { txtHostname.Text = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        public string Port
        {
            get { return txtPort.Text; }
            set { txtPort.Text = value; }
        }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>The schema.</value>
        public string Database
        {
            get { return txtDatabase.Text; }
            set { txtDatabase.Text = value; }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [windows authentication].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [windows authentication]; otherwise, <c>false</c>.
        /// </value>
        public bool WindowsAuthentication
        {
            get { return optWindowsAuth.Checked; }
            set { optWindowsAuth.Checked = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:frmLogin"/> class.
        /// </summary>
        /// <param name="DatabaseType">Type of the database.</param>
        public frmLogin(DatabaseTypes DatabaseType)
        {
            InitializeComponent();
            oDatabaseType = DatabaseType;

            //Only display check box if type is Microsoft Sql Server
            if (oDatabaseType == DatabaseTypes.SqlServer)
            {
                optWindowsAuth.Visible = true;
                txtPort.Text = "";
            }
            else
            {
                optWindowsAuth.Visible = false;
                if (txtPort.Text == "")
                    txtPort.Text = "3306";
            }

            if (optWindowsAuth.Checked == true)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnTest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void btnTest_Click(object sender, System.EventArgs e)
        {
            if (TestConnection() == false)
                MessageBox.Show("Connecton Failed!", "Test Connection");
            else
                MessageBox.Show("Connecton Successful!", "Test Connection");

        }

        /// <summary>
        /// Tests the connection.
        /// </summary>
        /// <returns>Returns true if connection is successful</returns>
        private bool TestConnection()
        {
            BuildConnectionString();

            //Check Database Type
            if (oDatabaseType == DatabaseTypes.SqlServer)
            {
                SqlConnection conTest = new SqlConnection(sConnectionString);
                try
                {
                    conTest.Open();
                }
                catch (Exception)
                {
                    return false;
                }

                conTest.Close();
                conTest.Dispose();
            }
            else if (oDatabaseType == DatabaseTypes.MySql)
            {
                MySqlConnection conTest = new MySqlConnection(sConnectionString);
                try
                {
                    conTest.Open();
                }
                catch (Exception)
                {
                    return false;
                }

                conTest.Close();
                conTest.Dispose();
            }

            return true;
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

            sConnectionString += txtDatabase.Text + ";";
            sConnectionString += "Data Source=" + txtHostname.Text;

            if (txtPort.Text != "")
                sConnectionString += /*":" + txtPort.Text +*/ ";";
            else
                sConnectionString += ";";

            //Check if Windows Authentication is selected
            if (optWindowsAuth.Checked == true)
            {
                sConnectionString += "Integrated Security=SSPI";
            }
            else
            {
                sConnectionString += "User Id=" + txtUsername.Text + ";";
                sConnectionString += "Password=" + txtPassword.Text + ";";
            }

        }

        /// <summary>
        /// Handles the CheckedChanged event of the optWindowsAuth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void optWindowsAuth_CheckedChanged(object sender, System.EventArgs e)
        {
            if (optWindowsAuth.Checked == true)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //Test Connection
            if (TestConnection() == false)
            {
                MessageBox.Show("Connection Failed!", "Test Connection");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }//class
}