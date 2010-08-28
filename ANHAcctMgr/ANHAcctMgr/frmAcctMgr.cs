using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ANHDBI;
using ANHDBI.MySQL;
using Utilities;
using ANHMySQLLib;
using ANHMySQLLib.Command;
using MySql.Data.MySqlClient;

namespace ANHAcctMgr
{
    public partial class frmAcctMgr : Form
    {
        List<Account> accounts = Account.GetAllAccounts();
        private Account objAccount;
        private bool flgAccountsLoaded = false;
        public frmAcctMgr()
        {
            InitializeComponent();
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
            cmbCreateType.SelectedItem = "Normal";
            listaccts();
            Global.Startup();
        }
        
        public void listaccts()
        {
            //lsvAccounts.Items.Clear();
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;

            flgAccountsLoaded = false;
            ListViewItem lsvItem;
            lsvAccounts.Items.Clear();

            if (flgAccountsLoaded == false)
            {
                accounts = Lists.GetAllAccounts();
                flgAccountsLoaded = false;
            }
            foreach (Account oAccount in accounts)
            {
                lsvItem = new ListViewItem(oAccount.UserName);
                //lsvItem.SubItems.Add(oClient.LastName);
                lsvItem.Tag = oAccount.Id.ToString();

                lsvAccounts.Items.Add(lsvItem);
            }
        }
        private void lsvAccounts_DoubleClick(object sender, EventArgs e)
        {
            // if (lsvAccounts.SelectedItems.Count <= 0)
            //{
            //    return;
            //}

            //objAccount = lsAccounts[int.Parse(lsvAccounts.SelectedItems[0].Tag.ToString())];

            //        txtUserName.Text = objAccount.Username;
            //        txtEmail.Text = objAccount.Email;
            //        string csrflag = objAccount.CSR.ToString();
            //if (csrflag == "0"){
            //    cmbCSR.SelectedItem = "Normal";
            //}
            //if (csrflag == "1")
            //{
            //    cmbCSR.SelectedItem = "CSR";
            //}
            //if (csrflag == "2")
            //{
            //    cmbCSR.SelectedItem = "Developer";
            //}
            //        txtBanned.Text = objAccount.Banned;
            //        txtChars.Text = objAccount.CharsAllowed;
            //        txtLastLogin.Text = objAccount.LastLogin;
            //        txtLastCreate.Text = objAccount.LastCreate;
            //        txtJoined.Text = objAccount.JoinDate;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //MySQLRunner.ConnectionString = clsDBStrings.utilitydbcon;
            //MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            //string sSQL = "";
            //int typevalue = 0;
            //if (cmbCreateType.SelectedItem == "Normal")
            //{
            //    typevalue = 0;
            //}
            //if (cmbCreateType.SelectedItem == "CSR")
            //{
            //    typevalue = 1;
            //}
            //if (cmbCreateType.SelectedItem == "Developer")
            //{
            //    typevalue = 2;
            //}
            //sSQL = "CALL sp_AdminAccountAdd('" + txtCreateUser.Text + "','" + txtCreatePass.Text + "','" + txtCreateEmail.Text + "', '" + typevalue + "', '" + txtCreateCharsAllowed.Text + "');";
            //if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
            //{
            //    MessageBox.Show("Error creating Account.");
            //}
            //else
            //{
            //    MessageBox.Show("Account Creation Successful.");
            //}
            //if (conAdd.State == ConnectionState.Open)
            //{
            //    conAdd.Close();
            //}
            //listaccts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            //objAccount.Username=txtUserName.Text;
            //objAccount.Email=txtEmail.Text;
            //if (cmbCSR.SelectedItem == "Normal")
            //{
            //    objAccount.CSR = 0;
            //}
            //if (cmbCSR.SelectedItem == "CSR")
            //{
            //    objAccount.CSR = 1;
            //}
            //if (cmbCSR.SelectedItem == "Developer")
            //{
            //    objAccount.CSR = 2;
            //}
            //if(txtBanned.Text == "True"){
            //objAccount.Banned = "1";
            //}
            //if (txtBanned.Text == "False")
            //{
            //    objAccount.Banned = "0";
            //}

            //objAccount.CharsAllowed = txtChars.Text;           
            //if (objAccount.Save() == true)
            //{
            //    MessageBox.Show("Update Successfull.", "Update Client");
            //    ClearAccount();
            //    listaccts();
            //}
            //else
            //    MessageBox.Show("Update Failed.", "Update Client");
        }

        private void btnPassUpdate_Click(object sender, EventArgs e)
        {
           //string accountid = lsvAccounts.SelectedItems[0].Tag.ToString();

           //MySQLRunner.ConnectionString = clsDBStrings.utilitydbcon;
           //MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
           //string sSQL = "";
           //string ID = lsvAccounts.SelectedItems[0].Tag.ToString();
           //sSQL = "CALL sp_AccountUpdatePassword('" + accountid.ToString() + "', '" + txtUpdatePass.Text + "');";
           //if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
           //    MessageBox.Show("Error Updating Password.");
           //else
           //    MessageBox.Show("Password Updated.");

           //if (conAdd.State == ConnectionState.Open)
           //{
           //    conAdd.Close();
           //}
           //listaccts();
           //ClearAccount();
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MySQLRunner.ConnectionString = clsDBStrings.utilitydbcon;
            //MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            //string sSQL = "";
            //string ID = lsvAccounts.SelectedItems[0].Tag.ToString();
            //sSQL = "CALL sp_AdminAccountDelete('" + ID.ToString() + "');";
            //if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
            //    MessageBox.Show("Error Deleting User.");
            //else
            //    MessageBox.Show("User Deleted.");

            //if (conAdd.State == ConnectionState.Open)
            //{
            //    conAdd.Close();
            //}
            //listaccts();
            //ClearAccount();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaccts();
            ClearAccount();
        }
    }
}
