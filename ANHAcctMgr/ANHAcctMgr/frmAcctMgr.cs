﻿using System;
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
        public frmAcctMgr()
        {
            InitializeComponent();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            MySQLRunner.ConnectionString = clsDBStrings.maindbcon;
            listaccts();
        }
        public void listaccts()
        {
            MySqlConnection conGet = new MySqlConnection(MySQLRunner.ConnectionString);
            MySqlDataReader drGet = null;
            string sSQL = "";
            sSQL = "SELECT * FROM account";

            if (MySQLRunner.ExecuteQuery(sSQL, conGet, ref drGet) == true)
            {
                ListViewItem lsvItem;
                while (drGet.Read())
                {
                    lsvItem = new ListViewItem(drGet.GetString(drGet.GetOrdinal("account_username")));
                    lsvItem.Tag = drGet.GetString(drGet.GetOrdinal("account_id"));
                    lsvAccounts.Items.Add(lsvItem);
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
        private void lsvAccounts_DoubleClick(object sender, EventArgs e)
        {
            if (lsvAccounts.SelectedItems.Count <= 0)
            {
                return;
            }

            string ID = lsvAccounts.SelectedItems[0].Tag.ToString();

            MySqlConnection conGet = new MySqlConnection(MySQLRunner.ConnectionString);
            MySqlDataReader drGet = null;
            string sSQL = "";
            sSQL = "SELECT * FROM account where account_id = '" + ID.ToString() + "'";

            if (MySQLRunner.ExecuteQuery(sSQL, conGet, ref drGet) == true)
            {
                drGet.Read();

                if (drGet.HasRows == false)
                {
                    txtUserName.Text = "";
                    txtEmail.Text = "";
                    txtCSR.Text = "";
                    txtBanned.Text = "";
                    txtChars.Text = "";
                }
                else
                {
                    txtUserName.Text = drGet.GetString(drGet.GetOrdinal("account_username"));
                    txtEmail.Text = drGet.GetString(drGet.GetOrdinal("account_email"));
                    txtCSR.Text = drGet.GetString(drGet.GetOrdinal("account_csr"));
                    txtBanned.Text = drGet.GetString(drGet.GetOrdinal("account_banned"));
                    txtChars.Text = drGet.GetString(drGet.GetOrdinal("account_characters_allowed"));
                }
            }

            if (conGet.State == ConnectionState.Open)
            {
                if (drGet != null)
                    drGet.Close();

                conGet.Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MySQLRunner.ConnectionString = clsDBStrings.configdbcon;
            MySqlConnection conAdd = new MySqlConnection(MySQLRunner.ConnectionString);
            string sSQL = "";
            bool flgReturn = false;
            sSQL = "CALL sp_AdminAddAccount('" + txtCreateUser.Text + "','" + txtCreatePass.Text + "','" + txtCreateEmail.Text + "');";
            if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
                MessageBox.Show("Error creating Account.");
            else
                MessageBox.Show("Account Creation Successful.");

            if (conAdd.State == ConnectionState.Open)
            {
                conAdd.Close();
            }

            //return flgReturn;
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
            if (txtBanned.Text == "True")
            {
                banned = "1";
            }
            else
            {
                banned = "0";
            }
            if (txtCSR.Text == "True")
            {
                csr = "1";
            }
            else
            {
                csr = "0";
            }

            sSQL = "UPDATE account SET " +
                     "account_username='" + txtUserName.Text + "', " +
                     "account_email='" + txtEmail.Text + "', " +
                     "account_banned='" + banned + "', " +
                     "account_csr='" + csr + "', " +
                     "account_characters_allowed='" + txtChars.Text + "' " +
                     "WHERE account_id=" + ID.ToString();


            if (MySQLRunner.ExecuteNonQuery(sSQL, conAdd) == false)
                MessageBox.Show("Error creating Account.");
            else
                MessageBox.Show("Account Creation Successful.");

            if (conAdd.State == ConnectionState.Open)
            {
                conAdd.Close();
            }
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
        }
    }
}
