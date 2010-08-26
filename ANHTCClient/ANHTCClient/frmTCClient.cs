using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace ANHTCClient
{
    public partial class frmTCClient : Form
    {
        TcpClient myclient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        string host = System.Configuration.ConfigurationManager.AppSettings["remotehost"];
        int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["remoteport"]);
        string passkey = System.Configuration.ConfigurationManager.AppSettings["remoteauth"];
        
        public frmTCClient()
        {
            InitializeComponent();
        }
        private void check_status(object sender, EventArgs e)
        {
            statusUtilities();
            statusZones();
        }
        private void statusZones()
        {
            string s;
            myclient = new TcpClient(host, port);
            //get a Network stream from the server
            networkStream = myclient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine("status,zones," + passkey + "");
            label6.Text = "Sending Request";
            streamWriter.Flush();
            s = streamReader.ReadLine();
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
            if (s == "success")
            {
                label5.ForeColor = Color.Lime;
                label5.Text = "ONLINE";
                label6.Text = "Request Completed";
            }
            if (s == "fail")
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Zones OFFLINE";
                label6.Text = "Request Completed";
            }

        }
        private void statusUtilities()
        {
            string s;
            myclient = new TcpClient(host, port);
            //get a Network stream from the server
            networkStream = myclient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine("status,utilities," + passkey + "");
            label6.Text = "Sending Request";
            streamWriter.Flush();
            s = streamReader.ReadLine();

            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
            if (s == "success")
            {
                label4.ForeColor = Color.Lime;
                label4.Text = "ONLINE";
                label6.Text = "Request Completed";
            }
            if (s == "fail")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "OFFLINE";
                label6.Text = "Request Completed";
            }
            
        }
        private void frmTCClient_Load(object sender, EventArgs e)
        {
            statusUtilities();
            statusZones();
        }

        private void btnUtilityStatus_Click(object sender, EventArgs e)
        {
            statusUtilities();
        }

        private void btnZoneStatus_Click(object sender, EventArgs e)
        {
            statusZones();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            myclient = new TcpClient(host, port);
            //get a Network stream from the server
            networkStream = myclient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine("start,utilities," + passkey + "");
            label6.Text = "Sending Request";
            streamWriter.Flush();
            s = streamReader.ReadLine();
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
            if (s == "success")
            {
                
                label6.Text = "Started SWG:ANH TC";
            }
            if (s == "fail")
            {
                label6.Text = "Failed to Start SWG:ANH TC";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s;
            myclient = new TcpClient(host, port);
            //get a Network stream from the server
            networkStream = myclient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine("stop,," + passkey + "");
            label6.Text = "Sending Request";
            streamWriter.Flush();
            s = streamReader.ReadLine();
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
            if (s == "success")
            {

                label6.Text = "Stopped SWG:ANH TC";
            }
            if (s == "fail")
            {
                label6.Text = "Failed to Stop SWG:ANH TC";
            }
        }
    }
}
