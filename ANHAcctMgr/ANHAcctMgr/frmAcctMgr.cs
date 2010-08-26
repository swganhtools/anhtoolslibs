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
using MySql.Data.MySqlClient;

namespace ANHAcctMgr
{
    public partial class frmAcctMgr : Form
    {
        private SortedList<int, Account> lsAccounts;
        private Account objAccount;
        private bool flgAccountsLoaded = false;
        public frmAcctMgr()
        {
            InitializeComponent();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            
            listaccts();
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
                lsAccounts = Lists.AccountList();
                flgAccountsLoaded = false;
            }
            foreach (Account oAccount in lsAccounts.Values)
            {
                lsvItem = new ListViewItem(oAccount.Username);
                //lsvItem.SubItems.Add(oClient.LastName);
                lsvItem.Tag = oAccount.ID.ToString();

                lsvAccounts.Items.Add(lsvItem);
            }
        }
        private void lsvAccounts_DoubleClick(object sender, EventArgs e)
        {
             if (lsvAccounts.SelectedItems.Count <= 0)
            {
                return;
            }

            objAccount = lsAccounts[int.Parse(lsvAccounts.SelectedItems[0].Tag.ToString())];

                    txtUserName.Text = objAccount.Username;
                    txtEmail.Text = objAccount.Email;
                    string csrflag = objAccount.CSR.ToString();
            if (csrflag == "0"){
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
                    txtCSR.Text = objAccount.CSR.ToString();
                    txtBanned.Text = objAccount.Banned;
                    txtChars.Text = objAccount.CharsAllowed;           
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MySQLRunner.ConnectionString = clsDBStrings.configdbcon;
            MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            bool flgReturn = false;
            sSQL = "CALL sp_AdminAddAccount('" + txtCreateUser.Text + "','" + txtCreatePass.Text + "','" + txtCreateEmail.Text + "');";
            if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
            {
                MessageBox.Show("Error creating Account.");
            }
            else
            {
                MessageBox.Show("Account Creation Successful.");
            }
            if (conAdd.State == ConnectionState.Open)
            {
                conAdd.Close();
            }            
            //return flgReturn;
            listaccts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            bool flgReturn = false;
            string banned = "";
            string csr = "";
            string ID = lsvAccounts.SelectedItems[0].Tag.ToString();
            

            sSQL = "UPDATE account SET " +
                     "account_username='" + txtUserName.Text + "', " +
                     "account_email='" + txtEmail.Text + "', " +
                     "account_banned='" + banned + "', " +
                     "account_csr='" + txtCSR.Text + "', " +
                     "account_characters_allowed='" + txtChars.Text + "' " +
                     "WHERE account_id=" + ID.ToString();


            if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
                MessageBox.Show("Error editing Account.");
            else
                MessageBox.Show("Account Update Successful.");

            if (conAdd.State == ConnectionState.Open)
            {
                conAdd.Close();
            }
            listaccts();
        }

        private void btnPassUpdate_Click(object sender, EventArgs e)
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            string ID = lsvAccounts.SelectedItems[0].Tag.ToString();
            sSQL = "UPDATE account SET " +
                     "account_password=SHA1('" + txtUpdatePass.Text + "') " +
                     "WHERE account_id=" + ID.ToString();
            if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
                MessageBox.Show("Error changing Password.");
            else
                MessageBox.Show("Password Change Successful.");

            if (conAdd.State == ConnectionState.Open)
            {
                conAdd.Close();
            }
            listaccts();
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            string ID = lsvAccounts.SelectedItems[0].Tag.ToString();
            sSQL = "DELETE from account " +
                   "WHERE account_id=" + ID.ToString();
            if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
                MessageBox.Show("Error Deleting User.");
            else
                MessageBox.Show("User Deleted.");

            if (conAdd.State == ConnectionState.Open)
            {
                conAdd.Close();
            }
            listaccts();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaccts();
        }
    }
}
