namespace ANHTCClient
{
    partial class frmTCClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTCClient));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUtilStatus = new System.Windows.Forms.Label();
            this.btnUtilityStatus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblZoneStatus = new System.Windows.Forms.Label();
            this.btnZoneStatus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.check_status);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Status:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Location = new System.Drawing.Point(13, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lblUtilStatus);
            this.splitContainer1.Panel1.Controls.Add(this.btnUtilityStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblZoneStatus);
            this.splitContainer1.Panel2.Controls.Add(this.btnZoneStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(411, 124);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUtilStatus
            // 
            this.lblUtilStatus.AutoSize = true;
            this.lblUtilStatus.Location = new System.Drawing.Point(55, 75);
            this.lblUtilStatus.Name = "lblUtilStatus";
            this.lblUtilStatus.Size = new System.Drawing.Size(88, 13);
            this.lblUtilStatus.TabIndex = 2;
            this.lblUtilStatus.Text = "Current Status";
            // 
            // btnUtilityStatus
            // 
            this.btnUtilityStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUtilityStatus.BackgroundImage")));
            this.btnUtilityStatus.Location = new System.Drawing.Point(47, 45);
            this.btnUtilityStatus.Name = "btnUtilityStatus";
            this.btnUtilityStatus.Size = new System.Drawing.Size(110, 23);
            this.btnUtilityStatus.TabIndex = 1;
            this.btnUtilityStatus.Text = "Get Status";
            this.btnUtilityStatus.UseVisualStyleBackColor = true;
            this.btnUtilityStatus.Click += new System.EventHandler(this.btnUtilityStatus_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Connection, Chat,Ping,Login";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblZoneStatus
            // 
            this.lblZoneStatus.AutoSize = true;
            this.lblZoneStatus.Location = new System.Drawing.Point(52, 75);
            this.lblZoneStatus.Name = "lblZoneStatus";
            this.lblZoneStatus.Size = new System.Drawing.Size(88, 13);
            this.lblZoneStatus.TabIndex = 4;
            this.lblZoneStatus.Text = "Current Status";
            // 
            // btnZoneStatus
            // 
            this.btnZoneStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoneStatus.BackgroundImage")));
            this.btnZoneStatus.Location = new System.Drawing.Point(41, 45);
            this.btnZoneStatus.Name = "btnZoneStatus";
            this.btnZoneStatus.Size = new System.Drawing.Size(110, 23);
            this.btnZoneStatus.TabIndex = 3;
            this.btnZoneStatus.Text = "Get Status";
            this.btnZoneStatus.UseVisualStyleBackColor = true;
            this.btnZoneStatus.Click += new System.EventHandler(this.btnZoneStatus_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "Zones - Tutorial, Tatooine, Naboo, Corellia";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(19, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start SWG:ANH TC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(223, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop SWG:ANH TC";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(412, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmTCClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ANHTCClient.Properties.Resources.lightgrey;
            this.ClientSize = new System.Drawing.Size(425, 228);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmTCClient";
            this.Text = "SWG:ANH TC Remote Administration";
            this.Load += new System.EventHandler(this.frmTCClient_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUtilStatus;
        private System.Windows.Forms.Button btnUtilityStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblZoneStatus;
        private System.Windows.Forms.Button btnZoneStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
    }
}