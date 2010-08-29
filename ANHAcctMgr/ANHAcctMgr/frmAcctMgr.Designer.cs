namespace ANHAcctMgr
{
    partial class frmAcctMgr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcctMgr));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.txtJoined = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLastCreate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLastLogin = new System.Windows.Forms.TextBox();
            this.cmbCSR = new System.Windows.Forms.ComboBox();
            this.btnPassUpdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUpdatePass = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtChars = new System.Windows.Forms.TextBox();
            this.txtBanned = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvAccounts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCreateCharsAllowed = new System.Windows.Forms.TextBox();
            this.cmbCreateType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCreatePass = new System.Windows.Forms.TextBox();
            this.txtCreateEmail = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(719, 377);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::ANHAcctMgr.Properties.Resources.offwhite;
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtJoined);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtLastCreate);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtLastLogin);
            this.tabPage1.Controls.Add(this.cmbCSR);
            this.tabPage1.Controls.Add(this.btnPassUpdate);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtUpdatePass);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lbl2);
            this.tabPage1.Controls.Add(this.txtChars);
            this.tabPage1.Controls.Add(this.txtBanned);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lsvAccounts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(711, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Edit Accounts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(143, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Joined";
            // 
            // txtJoined
            // 
            this.txtJoined.ForeColor = System.Drawing.Color.Black;
            this.txtJoined.Location = new System.Drawing.Point(274, 133);
            this.txtJoined.Name = "txtJoined";
            this.txtJoined.ReadOnly = true;
            this.txtJoined.Size = new System.Drawing.Size(234, 20);
            this.txtJoined.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Last Char Create";
            // 
            // txtLastCreate
            // 
            this.txtLastCreate.ForeColor = System.Drawing.Color.Black;
            this.txtLastCreate.Location = new System.Drawing.Point(275, 185);
            this.txtLastCreate.Name = "txtLastCreate";
            this.txtLastCreate.ReadOnly = true;
            this.txtLastCreate.Size = new System.Drawing.Size(234, 20);
            this.txtLastCreate.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Last Login";
            // 
            // txtLastLogin
            // 
            this.txtLastLogin.ForeColor = System.Drawing.Color.Black;
            this.txtLastLogin.Location = new System.Drawing.Point(275, 159);
            this.txtLastLogin.Name = "txtLastLogin";
            this.txtLastLogin.ReadOnly = true;
            this.txtLastLogin.Size = new System.Drawing.Size(234, 20);
            this.txtLastLogin.TabIndex = 20;
            // 
            // cmbCSR
            // 
            this.cmbCSR.FormattingEnabled = true;
            this.cmbCSR.Items.AddRange(new object[] {
            "Normal",
            "CSR",
            "Developer"});
            this.cmbCSR.Location = new System.Drawing.Point(273, 55);
            this.cmbCSR.Name = "cmbCSR";
            this.cmbCSR.Size = new System.Drawing.Size(121, 21);
            this.cmbCSR.TabIndex = 19;
            // 
            // btnPassUpdate
            // 
            this.btnPassUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPassUpdate.BackgroundImage")));
            this.btnPassUpdate.Location = new System.Drawing.Point(264, 308);
            this.btnPassUpdate.Name = "btnPassUpdate";
            this.btnPassUpdate.Size = new System.Drawing.Size(152, 23);
            this.btnPassUpdate.TabIndex = 17;
            this.btnPassUpdate.Text = "Update Password";
            this.btnPassUpdate.UseVisualStyleBackColor = true;
            this.btnPassUpdate.Click += new System.EventHandler(this.btnPassUpdate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Change Password";
            // 
            // txtUpdatePass
            // 
            this.txtUpdatePass.Location = new System.Drawing.Point(222, 282);
            this.txtUpdatePass.Name = "txtUpdatePass";
            this.txtUpdatePass.Size = new System.Drawing.Size(234, 20);
            this.txtUpdatePass.TabIndex = 15;
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.Location = new System.Drawing.Point(328, 239);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(152, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset Form";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::ANHAcctMgr.Properties.Resources.btn;
            this.btnSave.Location = new System.Drawing.Point(170, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save Account";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Chars Allowed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Banned";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "CSR";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(143, 33);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(37, 13);
            this.lbl2.TabIndex = 7;
            this.lbl2.Text = "Email";
            // 
            // txtChars
            // 
            this.txtChars.ForeColor = System.Drawing.Color.Black;
            this.txtChars.Location = new System.Drawing.Point(274, 108);
            this.txtChars.Name = "txtChars";
            this.txtChars.Size = new System.Drawing.Size(234, 20);
            this.txtChars.TabIndex = 6;
            // 
            // txtBanned
            // 
            this.txtBanned.ForeColor = System.Drawing.Color.Black;
            this.txtBanned.Location = new System.Drawing.Point(274, 82);
            this.txtBanned.Name = "txtBanned";
            this.txtBanned.Size = new System.Drawing.Size(120, 20);
            this.txtBanned.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(274, 30);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(234, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.Location = new System.Drawing.Point(274, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(234, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName";
            // 
            // lsvAccounts
            // 
            this.lsvAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvAccounts.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvAccounts.ForeColor = System.Drawing.Color.Black;
            this.lsvAccounts.GridLines = true;
            this.lsvAccounts.Location = new System.Drawing.Point(8, 7);
            this.lsvAccounts.Name = "lsvAccounts";
            this.lsvAccounts.Size = new System.Drawing.Size(130, 339);
            this.lsvAccounts.TabIndex = 0;
            this.lsvAccounts.UseCompatibleStateImageBehavior = false;
            this.lsvAccounts.View = System.Windows.Forms.View.Details;
            this.lsvAccounts.DoubleClick += new System.EventHandler(this.lsvAccounts_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Acct. Name";
            this.columnHeader1.Width = 115;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.deleteMemberToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 48);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // deleteMemberToolStripMenuItem
            // 
            this.deleteMemberToolStripMenuItem.Name = "deleteMemberToolStripMenuItem";
            this.deleteMemberToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteMemberToolStripMenuItem.Text = "Delete Member";
            this.deleteMemberToolStripMenuItem.Click += new System.EventHandler(this.deleteMemberToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::ANHAcctMgr.Properties.Resources.offwhite;
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtCreateCharsAllowed);
            this.tabPage2.Controls.Add(this.cmbCreateType);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.btnCreate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtCreatePass);
            this.tabPage2.Controls.Add(this.txtCreateEmail);
            this.tabPage2.Controls.Add(this.txtCreateUser);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(711, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create New Account";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Chars Allowed";
            // 
            // txtCreateCharsAllowed
            // 
            this.txtCreateCharsAllowed.Location = new System.Drawing.Point(152, 82);
            this.txtCreateCharsAllowed.Name = "txtCreateCharsAllowed";
            this.txtCreateCharsAllowed.Size = new System.Drawing.Size(234, 20);
            this.txtCreateCharsAllowed.TabIndex = 22;
            // 
            // cmbCreateType
            // 
            this.cmbCreateType.FormattingEnabled = true;
            this.cmbCreateType.Items.AddRange(new object[] {
            "Normal",
            "CSR",
            "Developer"});
            this.cmbCreateType.Location = new System.Drawing.Point(152, 108);
            this.cmbCreateType.Name = "cmbCreateType";
            this.cmbCreateType.Size = new System.Drawing.Size(180, 21);
            this.cmbCreateType.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Account Type";
            // 
            // btnCreate
            // 
            this.btnCreate.BackgroundImage = global::ANHAcctMgr.Properties.Resources.btn;
            this.btnCreate.Location = new System.Drawing.Point(152, 164);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(209, 23);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create New Account";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Email";
            // 
            // txtCreatePass
            // 
            this.txtCreatePass.Location = new System.Drawing.Point(152, 56);
            this.txtCreatePass.Name = "txtCreatePass";
            this.txtCreatePass.Size = new System.Drawing.Size(234, 20);
            this.txtCreatePass.TabIndex = 12;
            // 
            // txtCreateEmail
            // 
            this.txtCreateEmail.Location = new System.Drawing.Point(152, 30);
            this.txtCreateEmail.Name = "txtCreateEmail";
            this.txtCreateEmail.Size = new System.Drawing.Size(234, 20);
            this.txtCreateEmail.TabIndex = 11;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(152, 4);
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.Size = new System.Drawing.Size(234, 20);
            this.txtCreateUser.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "UserName";
            // 
            // frmAcctMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ANHAcctMgr.Properties.Resources.lightgrey;
            this.ClientSize = new System.Drawing.Size(728, 384);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmAcctMgr";
            this.Text = "SWG:ANH Account Manager";
            this.Load += new System.EventHandler(this.frmAccounts_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lsvAccounts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txtChars;
        private System.Windows.Forms.TextBox txtBanned;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCreatePass;
        private System.Windows.Forms.TextBox txtCreateEmail;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPassUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUpdatePass;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMemberToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbCSR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLastLogin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLastCreate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtJoined;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCreateCharsAllowed;
        private System.Windows.Forms.ComboBox cmbCreateType;
        private System.Windows.Forms.Label label12;
    }
}