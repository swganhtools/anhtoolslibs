using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using ServiceClient.ANHService;
using ANH_WCF_Interface;
using System.Security.Cryptography;

namespace ServiceClient
{
    public partial class frmClient : Form
    {
        AnhCallback ServerCallback = null;
        AnhServiceClient client = null;
        InstanceContext ic = null;
        public frmClient()
        {
            ServerCallback = new AnhCallback();
            InitializeComponent();
            ServerCallback.MessageReceived += new EventHandler<MessageEventArgs>(ServerCallback_MessageReceived);
            ServerCallback.AvailableServerListReceived += new EventHandler<AvailableServerEventArgs>(ServerCallback_AvailableServerListReceived);
            ServerCallback.StatusReceived += new EventHandler<ServerStatusEventArgs>(ServerCallback_StatusReceived);

            ic = new InstanceContext(ServerCallback);
            client = new AnhServiceClient(ic);
            ic.Faulted += new EventHandler(ic_Faulted);
            ic.Open();
            Servers s = new Servers(ServerType1.ConnectionServer, "");
            comboBox1.Items.Add(s);
            s = new Servers(ServerType1.ChatServer, "");
            comboBox1.Items.Add(s);
            s = new Servers(ServerType1.LoginServer, "");
            comboBox1.Items.Add(s);
            s = new Servers(ServerType1.PingServer, "");
            comboBox1.Items.Add(s);
            s = new Servers(ServerType1.ZoneServer, "tutorial");
            comboBox1.Items.Add(s);
            s = new Servers(ServerType1.ZoneServer, "tatooine");
            comboBox1.Items.Add(s);
            comboBox1.SelectedIndex = 0;
        }

        void ic_Faulted(object sender, EventArgs e)
        {
            ic.Abort();
            ic = new InstanceContext(ServerCallback);
            ic.Open();
            listBox1.Items.Add("Channel Fault repaired");
        }

        void ServerCallback_StatusReceived(object sender, ServerStatusEventArgs e)
        {
            if (e.StatusList == null)
                return;

            listBox1.Items.Add("Got statuses for " + e.StatusList.Count + " Servers");
            foreach (IServerStatus iss in e.StatusList)
            {
                listBox1.Items.Add(iss.type.ToString() + ": " + iss.args + " Running: " + iss.IsRunning + " Crashed: " + iss.IsCrashed + " Uptime (s): " + iss.Uptime / 1000);
            }
        }

        void ServerCallback_AvailableServerListReceived(object sender, AvailableServerEventArgs e)
        {
            List<ServerType1> t = e.ServerList;
            listBox1.Items.Add(t.Count + " types of servers are available");
            foreach (ServerType1 st in t)
            {
                listBox1.Items.Add(st);
            }
        }

        void ServerCallback_MessageReceived(object sender, MessageEventArgs e)
        {
            listBox1.Items.Add(e.ServerType.ToString() + ": " + e.Message);
        }

        private void frmClient_Load(object sender, EventArgs e)
        {

        }
    }
}
