using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ANHMySQLLib;
using ANHMySQLLib.Command;
using MySql.Data.MySqlClient;
using System.Threading;

namespace ANHAcctMgr
{
    delegate void DelegateVoid();

    public partial class frmAcctMgr : Form
    {
        // doing this would call a db access before everything
       // List<Account> accounts = Lists.GetAllAccounts(); <-- this line is called first it then
        // triggerd the sql query but the engine wasnt started
        Dictionary<int, Account> accounts;
        private Account objAccount;
        private bool flgAccountsLoaded = false;
        int stationid = 0;
        public frmAcctMgr()
        {
           
            // that was to avoid starting 2 times the same 'mini-app'
            bool notExisting = false;
            Mutex mutex = new Mutex(true, "AccountManager", out notExisting);

            if (notExisting)
            {
                
                
                InitializeComponent();


            }
            else
            {
                MessageBox.Show("Another instance is already running");
                this.Close();
            }

            GC.KeepAlive(mutex);

            accounts = new Dictionary<int, Account>();
        }
        private void ClearAccount()
        {
            txtUserName.Text = "";
            txtEmail.Text = "";
            cmbCSR.SelectedItem = "Normal";
            txtBanned.Text = "";
            txtChars.Text = "";
            txtLastLogin.Text = "";
            txtLastCreate.Text = "";
            txtJoined.Text = "";
            txtUpdatePass.Text = "";
        }

        
        private void frmAccounts_Load(object sender, EventArgs e)
        {

            Database.Startup();

            this.FormClosed += new FormClosedEventHandler(frmAcctMgr_FormClosed);

            cmbCreateType.SelectedItem = "Normal";

            listaccts2(); // i made a new method so you can see how it works
            
          
        }

        void frmAcctMgr_FormClosed(object sender, FormClosedEventArgs e)
        {
    
            Database.Shutdown();
        }
        
        public void listaccts()
        {
            //lsvAccounts.Items.Clear();
           // MySQLRunner.ConnectionString = clsDBStrings.maindbcon;

            flgAccountsLoaded = false;
            ListViewItem lsvItem;
            lsvAccounts.Items.Clear();

            if (flgAccountsLoaded == false)
            {
               // accounts = Lists.GetAllAccounts();
                flgAccountsLoaded = false;
            }/*
            foreach (Account oAccount in accounts)
            {
                lsvItem = new ListViewItem(oAccount.UserName);
                //lsvItem.SubItems.Add(oClient.LastName);
                lsvItem.Tag = oAccount.Id.ToString();

                lsvAccounts.Items.Add(lsvItem);
            }*/
        }

        public void listaccts2()
        {
            lsvAccounts.Items.Clear();
            accounts.Clear();

            AsyncMysqlQuery query = new AsyncMysqlQuery("CALL swganh_utility.sp_AdminAccountList();");

            query.SetHandler(delegate(MySqlDataReader reader)
            {
                if (query.Error == null)
                {
                    while (reader.Read())
                    {
                        Account account = new Account(reader);

                        ListViewItem lsvItem = new ListViewItem(account.UserName);
                       
                        lsvItem.Tag = account.Id.ToString();
                        accounts.Add(account.Id, account);
                        // we must do this to handle cross-thread operations
                        lsvAccounts.Invoke(new DelegateVoid(delegate()
                        {
                            lsvAccounts.Items.Add(lsvItem);
                        }));
                    }
                }
                else
                {
                    Console.WriteLine("something went wrong");
                }


            });

            Database.Utility.ExecuteSync(query);
        }
        private void lsvAccounts_DoubleClick(object sender, EventArgs e)
        {
             if (lsvAccounts.SelectedItems.Count <= 0)
            {
                return;
            }
            // theres the problem
            // you can put an Object in the Tag instead ioof a string

            // the list is null

            int clickedId = int.Parse(lsvAccounts.SelectedItems[0].Tag.ToString());

            if(accounts.ContainsKey(clickedId))
            {
                Account clickedAccount = accounts[clickedId];
                txtUserName.Text = clickedAccount.UserName;
                txtEmail.Text = clickedAccount.Email;
                string csrflag = clickedAccount.CSR.ToString();
                stationid = clickedAccount.StationID;
                if (csrflag == "0")
                {
                    cmbCSR.SelectedItem = "Normal";
                }
                if (csrflag == "1")
                {
                    cmbCSR.SelectedItem = "CSR";
                }
                if (csrflag == "2")
                {
                    cmbCSR.SelectedItem = "Developer";
                }
                       txtBanned.Text = clickedAccount.Banned;
                       txtChars.Text = clickedAccount.CharsAllowed;
                       txtLastLogin.Text = clickedAccount.LastLogin;
                       txtLastCreate.Text = clickedAccount.LastCreate;
                       txtJoined.Text = clickedAccount.Joined;
            }
            else
            {
                MessageBox.Show("Dunno that account", "O_o");
            }
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int typevalue = 0;
            if (cmbCreateType.SelectedItem == "Normal")
                {
                    typevalue = 0;
                }
                if (cmbCreateType.SelectedItem == "CSR")
                {

                    typevalue = 1;
                }
                if (cmbCreateType.SelectedItem == "Developer")
                {
                    typevalue = 2;
                }
            MySqlCommand command = new MySqlCommand("sp_AdminAccountAdd");

                command.Parameters.Add(new MySqlParameter("username", txtCreateUser.Text));
                command.Parameters.Add(new MySqlParameter("userpass", txtCreatePass.Text));
                command.Parameters.Add(new MySqlParameter("email", txtCreateEmail.Text));
                command.Parameters.Add(new MySqlParameter("accounttype", typevalue));
                command.Parameters.Add(new MySqlParameter("maxcharsallowed", int.Parse(txtCreateCharsAllowed.Text)));

                command.CommandType = System.Data.CommandType.StoredProcedure;

                AsyncMysqlQuery query = new AsyncMysqlQuery(command);

                query.SetHandler(delegate(MySqlDataReader reader)
                {
                    if (query.Error == null)
                    {
                        MessageBox.Show("Creation Successfull");
                        //Console.WriteLine("query completed ({0} fields)", reader.FieldCount);
                        ClearAccount();
                        listaccts2();
                    }
                    else
                    {
                        //Console.WriteLine("something went wrong");
                        //Console.WriteLine(query.Error.Message);
                        MessageBox.Show(query.Error.Message);
                    }
                });
        
                Database.Utility.ExecuteAsync(query);
            
            //listaccts2();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             int csrflag = 0;
                if (cmbCSR.SelectedItem == "Normal")
                {
                    csrflag = 0;
                }
                if (cmbCSR.SelectedItem == "CSR")
                {
                    
                    csrflag = 1;
                }
                if (cmbCSR.SelectedItem == "Developer")
                {
                    csrflag = 2;
                }
            int clickedId = int.Parse(lsvAccounts.SelectedItems[0].Tag.ToString());

            if (accounts.ContainsKey(clickedId))
            {
                MySqlCommand command = new MySqlCommand("sp_AdminAccountUpdate");

                command.Parameters.Add(new MySqlParameter("mAccoundID", clickedId));
                command.Parameters.Add(new MySqlParameter("mAccountUsername", txtUserName.Text));
                command.Parameters.Add(new MySqlParameter("mAccountStationID", stationid));
                command.Parameters.Add(new MySqlParameter("mAccountCSR", csrflag));
                command.Parameters.Add(new MySqlParameter("mAccountEmail", txtEmail.Text));
                command.Parameters.Add(new MySqlParameter("mAccountBanned", txtBanned.Text));
                command.Parameters.Add(new MySqlParameter("mAccountCharsAllowed", txtChars.Text));

                command.CommandType = System.Data.CommandType.StoredProcedure;

                AsyncMysqlQuery query = new AsyncMysqlQuery(command);

                query.SetHandler(delegate(MySqlDataReader reader)
                {
                    if (query.Error == null)
                    {
                        MessageBox.Show("Updated Successfully");
                        //Console.WriteLine("query completed ({0} fields)", reader.FieldCount);
                        ClearAccount();
                        listaccts2();
                    }
                    else
                    {
                        //Console.WriteLine("something went wrong");
                        //Console.WriteLine(query.Error.Message);
                        MessageBox.Show(query.Error.Message);
                    }
                });

                Database.Utility.ExecuteAsync(query);
            }
            //listaccts2();
        }

        private void btnPassUpdate_Click(object sender, EventArgs e)
        {
            int clickedId = int.Parse(lsvAccounts.SelectedItems[0].Tag.ToString());

            if (accounts.ContainsKey(clickedId))
            {
                MySqlCommand command = new MySqlCommand("sp_AccountUpdatePassword");

                command.Parameters.Add(new MySqlParameter("accountid", clickedId));
                command.Parameters.Add(new MySqlParameter("userpass", txtUpdatePass.Text));

                command.CommandType = System.Data.CommandType.StoredProcedure;

                AsyncMysqlQuery query = new AsyncMysqlQuery(command);

                query.SetHandler(delegate(MySqlDataReader reader)
                {
                    if (query.Error == null)
                    {
                        MessageBox.Show("Updated Successfully");
                        //Console.WriteLine("query completed ({0} fields)", reader.FieldCount);
                        ClearAccount();
                        listaccts2();
                    }
                    else
                    {
                        //Console.WriteLine("something went wrong");
                        //Console.WriteLine(query.Error.Message);
                        MessageBox.Show(query.Error.Message);
                    }
                });

                Database.Utility.ExecuteAsync(query);
            }
           //ClearAccount();
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int clickedId = int.Parse(lsvAccounts.SelectedItems[0].Tag.ToString());

            if (accounts.ContainsKey(clickedId))
            {
                MySqlCommand command = new MySqlCommand("sp_AdminAccountDelete");

                command.Parameters.Add(new MySqlParameter("accountid", clickedId));               

                command.CommandType = System.Data.CommandType.StoredProcedure;

                AsyncMysqlQuery query = new AsyncMysqlQuery(command);

                query.SetHandler(delegate(MySqlDataReader reader)
                {
                    if (query.Error == null)
                    {
                        MessageBox.Show("Updated Successfully");
                        //Console.WriteLine("query completed ({0} fields)", reader.FieldCount);
                        ClearAccount();
                        listaccts2();
                    }
                    else
                    {
                        //Console.WriteLine("something went wrong");
                        //Console.WriteLine(query.Error.Message);
                        MessageBox.Show(query.Error.Message);
                    }
                });

                Database.Utility.ExecuteAsync(query);
                listaccts2();
                ClearAccount();
            }
            
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaccts2();
            ClearAccount();
        }

       
    }
}
