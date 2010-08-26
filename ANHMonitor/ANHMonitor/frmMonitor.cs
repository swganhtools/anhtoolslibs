using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using ProcessCallerLibrary;

namespace ANHMonitor
{
    public partial class frmMonitor : Form
    {
        string host = System.Configuration.ConfigurationManager.AppSettings["remotehost"];
        int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["remoteport"]);
        string passkey = System.Configuration.ConfigurationManager.AppSettings["remoteauth"];
        public frmMonitor()
        {
            InitializeComponent();
        }
        ProcessCaller connectionserver = null;
        ProcessCaller chatserver = null;
        ProcessCaller pingserver = null;
        ProcessCaller loginserver = null;

        ProcessCaller tutorialzone = null;
        ProcessCaller tatooinezone = null;
        ProcessCaller corelliazone = null;
        ProcessCaller dantooinezone = null;
        ProcessCaller dathomirzone = null;
        ProcessCaller endorzone = null;
        ProcessCaller lokzone = null;
        ProcessCaller naboozone = null;
        ProcessCaller rorizone = null;
        ProcessCaller taluszone = null;
        ProcessCaller yavinzone = null;
        bool flgThreadRunning = false;
        bool flgStartAnh = false;
        bool flgRestartAnh = false;
        bool flgStopAnh = false;
        
        //
        // Process Utility Server Starts
        //
        public void conserver()
        {

            connectionserver = new ProcessCaller(this);
            connectionserver.FileName = "connectionserver.exe";
            connectionserver.WorkingDirectory = "";
            connectionserver.Arguments = "";
            connectionserver.StdErrReceived += new DataReceivedHandler(writeConnStreamInfo);
            connectionserver.StdOutReceived += new DataReceivedHandler(writeConnStreamInfo);
            connectionserver.Completed += new EventHandler(connectionCompleted);
            connectionserver.Cancelled += new EventHandler(connectionCanceled);
            connectionserver.Start();
            //flgConnection = true;
        }
        public void chtserver()
        {
            chatserver = new ProcessCaller(this);
            chatserver.FileName = "chatserver.exe";
            chatserver.WorkingDirectory = "";
            chatserver.Arguments = "";
            chatserver.StdErrReceived += new DataReceivedHandler(writeChatStreamInfo);
            chatserver.StdOutReceived += new DataReceivedHandler(writeChatStreamInfo);
            chatserver.Completed += new EventHandler(chatCompleted);
            chatserver.Cancelled += new EventHandler(chatCanceled);
            chatserver.Start();
            //flgChat = true;
        }
        public void pngserver()
        {
            pingserver = new ProcessCaller(this);
            pingserver.FileName = "pingserver.exe";
            pingserver.WorkingDirectory = "";
            pingserver.Arguments = "";
            pingserver.StdErrReceived += new DataReceivedHandler(writePingStreamInfo);
            pingserver.StdOutReceived += new DataReceivedHandler(writePingStreamInfo);
            pingserver.Completed += new EventHandler(pingCompleted);
            pingserver.Cancelled += new EventHandler(pingCanceled);
            pingserver.Start();
            //flgPing = true;
        }
        public void logserver()
        {
            loginserver = new ProcessCaller(this);
            loginserver.FileName = "loginserver.exe";
            loginserver.WorkingDirectory = "";
            loginserver.Arguments = "";
            loginserver.StdErrReceived += new DataReceivedHandler(writeLoginStreamInfo);
            loginserver.StdOutReceived += new DataReceivedHandler(writeLoginStreamInfo);
            loginserver.Completed += new EventHandler(loginCompleted);
            loginserver.Cancelled += new EventHandler(loginCanceled);
            loginserver.Start();
           // flgLogin = true;
        }
        //
        //Connection Server
        //
        private void connectionCanceled(object sender, EventArgs e)
        {
           txtConnection.AppendText("ConnectionServer Exited.\n");
           connectionserver = null;
        }        
        private void connectionCompleted(object sender, EventArgs e)
        {           
            txtConnection.AppendText("ConnectionServer crashed.\n");
            connectionserver = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        //
        //Chat Server
        //
        private void chatCanceled(object sender, EventArgs e)
        {
            txtChat.AppendText("Chat Server Exited.\n");
            chatserver = null;
        }
        private void chatCompleted(object sender, EventArgs e)
        {
            txtChat.AppendText("Chat Server crashed.\n");
            chatserver = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        //
        //Ping Server
        //
        private void pingCanceled(object sender, EventArgs e)
        {
            txtPing.AppendText("Ping Server Exited.\n");
            pingserver = null;
        }
        private void pingCompleted(object sender, EventArgs e)
        {
            txtPing.AppendText("Ping Server crashed.\n");
            pingserver = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        //
        //Login Server
        //
        private void loginCanceled(object sender, EventArgs e)
        {
            txtLogin.AppendText("Login Server Exited.\n");
            loginserver = null;
        }
        private void loginCompleted(object sender, EventArgs e)
        {
            txtLogin.AppendText("Login Server crashed.\n");
            loginserver = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void writeConnStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtConnection.AppendText(e.Text + Environment.NewLine);
        }
        private void writeLoginStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtLogin.AppendText(e.Text + Environment.NewLine);
        }
        private void writePingStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtPing.AppendText(e.Text + Environment.NewLine);
        }
        private void writeChatStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtChat.AppendText(e.Text + Environment.NewLine);
        }
        //ZONES
        public void zonetutorial()
        {
            tutorialzone = new ProcessCaller(this);
            tutorialzone.FileName = "zoneserver.exe";
            tutorialzone.WorkingDirectory = "";
            tutorialzone.Arguments = "tutorial";
            tutorialzone.StdErrReceived += new DataReceivedHandler(writeTutorialStreamInfo);
            tutorialzone.StdOutReceived += new DataReceivedHandler(writeTutorialStreamInfo);
            tutorialzone.Completed += new EventHandler(tutorialCompleted);
            tutorialzone.Cancelled += new EventHandler(tutorialCanceled);
            tutorialzone.Start();
           // flgTutorialStarted = true;
        }
        public void zonetatooine()
        {
            tatooinezone = new ProcessCaller(this);
            tatooinezone.FileName = "zoneserver.exe";
            tatooinezone.WorkingDirectory = "";
            tatooinezone.Arguments = "tatooine";
            tatooinezone.StdErrReceived += new DataReceivedHandler(writeTatooineStreamInfo);
            tatooinezone.StdOutReceived += new DataReceivedHandler(writeTatooineStreamInfo);
            tatooinezone.Completed += new EventHandler(tatooineCompleted);
            tatooinezone.Cancelled += new EventHandler(tatooineCanceled);
            tatooinezone.Start();
            //flgTatooineStarted = true;
        }
        public void zonecorellia()
        {
            corelliazone = new ProcessCaller(this);
            corelliazone.FileName = "zoneserver.exe";
            corelliazone.WorkingDirectory = "";
            corelliazone.Arguments = "corellia";
            corelliazone.StdErrReceived += new DataReceivedHandler(writeCorelliaStreamInfo);
            corelliazone.StdOutReceived += new DataReceivedHandler(writeCorelliaStreamInfo);
            corelliazone.Completed += new EventHandler(corelliaCompleted);
            corelliazone.Cancelled += new EventHandler(corelliaCanceled);
            corelliazone.Start();
            //flgCorelliaStarted = true;
        }
        public void zonedantooine()
        {
            dantooinezone = new ProcessCaller(this);
            dantooinezone.FileName = "zoneserver.exe";
            dantooinezone.WorkingDirectory = "";
            dantooinezone.Arguments = "dantooine";
            dantooinezone.StdErrReceived += new DataReceivedHandler(writeDantooineStreamInfo);
            dantooinezone.StdOutReceived += new DataReceivedHandler(writeDantooineStreamInfo);
            dantooinezone.Completed += new EventHandler(dantooineCompleted);
            dantooinezone.Cancelled += new EventHandler(dantooineCanceled);
            dantooinezone.Start();
           // flgDantooineStarted = true;
        }
        public void zonedathomir()
        {
            dathomirzone = new ProcessCaller(this);
            dathomirzone.FileName = "zoneserver.exe";
            dathomirzone.WorkingDirectory = "";
            dathomirzone.Arguments = "dathomir";
            dathomirzone.StdErrReceived += new DataReceivedHandler(writeDathomirStreamInfo);
            dathomirzone.StdOutReceived += new DataReceivedHandler(writeDathomirStreamInfo);
            dathomirzone.Completed += new EventHandler(dathomirCompleted);
            dathomirzone.Cancelled += new EventHandler(dathomirCanceled);
            dathomirzone.Start();
            //flgDathomirStarted = true;
        }
        public void zoneendor()
        {
            endorzone = new ProcessCaller(this);
            endorzone.FileName = "zoneserver.exe";
            endorzone.WorkingDirectory = "";
            endorzone.Arguments = "endor";
            endorzone.StdErrReceived += new DataReceivedHandler(writeEndorStreamInfo);
            endorzone.StdOutReceived += new DataReceivedHandler(writeEndorStreamInfo);
            endorzone.Completed += new EventHandler(endorCompleted);
            endorzone.Cancelled += new EventHandler(endorCanceled);
            endorzone.Start();
            //flgEndorStarted = true;
        }
        public void zonelok()
        {
            lokzone = new ProcessCaller(this);
            lokzone.FileName = "zoneserver.exe";
            lokzone.WorkingDirectory = "";
            lokzone.Arguments = "lok";
            lokzone.StdErrReceived += new DataReceivedHandler(writeLokStreamInfo);
            lokzone.StdOutReceived += new DataReceivedHandler(writeLokStreamInfo);
            lokzone.Completed += new EventHandler(lokCompleted);
            lokzone.Cancelled += new EventHandler(lokCanceled);
            lokzone.Start();
            //flgLokStarted = true;
        }
        public void zonenaboo()
        {
            naboozone = new ProcessCaller(this);
            naboozone.FileName = "zoneserver.exe";
            naboozone.WorkingDirectory = "";
            naboozone.Arguments = "naboo";
            naboozone.StdErrReceived += new DataReceivedHandler(writeNabooStreamInfo);
            naboozone.StdOutReceived += new DataReceivedHandler(writeNabooStreamInfo);
            naboozone.Completed += new EventHandler(nabooCompleted);
            naboozone.Cancelled += new EventHandler(nabooCanceled);
            naboozone.Start();
            //flgNabooStarted = true;
        }
        public void zonerori()
        {
            rorizone = new ProcessCaller(this);
            rorizone.FileName = "zoneserver.exe";
            rorizone.WorkingDirectory = "";
            rorizone.Arguments = "rori";
            rorizone.StdErrReceived += new DataReceivedHandler(writeRoriStreamInfo);
            rorizone.StdOutReceived += new DataReceivedHandler(writeRoriStreamInfo);
            rorizone.Completed += new EventHandler(roriCompleted);
            rorizone.Cancelled += new EventHandler(roriCanceled);
            rorizone.Start();
            //flgRoriStarted = true;
        }
        public void zonetalus()
        {
            taluszone = new ProcessCaller(this);
            taluszone.FileName = "zoneserver.exe";
            taluszone.WorkingDirectory = "";
            taluszone.Arguments = "talus";
            taluszone.StdErrReceived += new DataReceivedHandler(writeTalusStreamInfo);
            taluszone.StdOutReceived += new DataReceivedHandler(writeTalusStreamInfo);
            taluszone.Completed += new EventHandler(talusCompleted);
            taluszone.Cancelled += new EventHandler(talusCanceled);
            taluszone.Start();
            //flgTalusStarted = true;
        }
        public void zoneyavin()
        {
            yavinzone = new ProcessCaller(this);
            yavinzone.FileName = "zoneserver.exe";
            yavinzone.WorkingDirectory = "";
            yavinzone.Arguments = "yavin4";
            yavinzone.StdErrReceived += new DataReceivedHandler(writeYavinStreamInfo);
            yavinzone.StdOutReceived += new DataReceivedHandler(writeYavinStreamInfo);
            yavinzone.Completed += new EventHandler(yavinCompleted);
            yavinzone.Cancelled += new EventHandler(yavinCanceled);
            yavinzone.Start();
            //flgYavinStarted = true;
        }
        
        private void tutorialCompleted(object sender, EventArgs e)
        {
            txtTutorial.AppendText("Tutorial Crash.\n");
            tutorialzone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void tutorialCanceled(object sender, EventArgs e)
        {
            txtTutorial.AppendText("Tutorial Stopped by user.\n");
            tutorialzone = null;
        }
        //
        //Corellia
        //
        private void corelliaCompleted(object sender, EventArgs e)
        {
            txtCorellia.AppendText("Corellia Crash.\n");
            corelliazone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void corelliaCanceled(object sender, EventArgs e)
        {
            txtCorellia.AppendText("Corellia Stopped by user.\n");
            corelliazone = null;
        }
        //
        //Dantooine
        //
        private void dantooineCompleted(object sender, EventArgs e)
        {
            txtDantooine.AppendText("Dantooine Crash.\n");
            dantooinezone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void dantooineCanceled(object sender, EventArgs e)
        {
            txtDantooine.AppendText("Dantooine Stopped by user.");
            dantooinezone = null;
        }
        //
        //Dathomir
        //
        private void dathomirCompleted(object sender, EventArgs e)
        {
            txtDathomir.AppendText("Dantooine Crash.\n");
            dathomirzone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void dathomirCanceled(object sender, EventArgs e)
        {
            txtDathomir.AppendText("Dathomir Stopped by user.\n");
            dathomirzone = null;
        }
        //
        //Endor
        //
        private void endorCompleted(object sender, EventArgs e)
        {
            txtEndor.AppendText("Endor Crash.\n");
            endorzone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void endorCanceled(object sender, EventArgs e)
        {
            txtEndor.AppendText("Endor Stopped by user.\n");
            endorzone = null;
        }
        //
        //Lok
        //
        private void lokCompleted(object sender, EventArgs e)
        {
            txtLok.AppendText("Lok Crash.\n");
            lokzone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void lokCanceled(object sender, EventArgs e)
        {
            txtLok.AppendText("Lok Stopped by user.\n");
            lokzone = null;
        }
        //
        //Naboo
        //
        private void nabooCompleted(object sender, EventArgs e)
        {
            txtNaboo.AppendText("Naboo Crash.\n");
            naboozone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void nabooCanceled(object sender, EventArgs e)
        {
            txtNaboo.AppendText("Naboo Stopped by user.\n");
            naboozone = null;
        }
        //
        //Rori
        //
        private void roriCompleted(object sender, EventArgs e)
        {
            txtRori.AppendText("Rori Crash.\n");
            rorizone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void roriCanceled(object sender, EventArgs e)
        {
            txtRori.AppendText("Rori Stopped by user.\n");
            rorizone = null;
        }
        //
        //Talus
        //
        private void talusCompleted(object sender, EventArgs e)
        {
            txtTalus.AppendText("Talus Crash.\n");
            taluszone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void talusCanceled(object sender, EventArgs e)
        {
            txtTalus.AppendText("Talus Stopped by user.\n");
            taluszone = null;
        }
        //
        //Tatooine
        //
        private void tatooineCompleted(object sender, EventArgs e)
        {
            txtTatooine.AppendText("Tatooine Crash.\n");
            tatooinezone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void tatooineCanceled(object sender, EventArgs e)
        {
            txtTatooine.AppendText("TAtooine Stopped by user.\n");
            tatooinezone = null;
        }
        //
        //Yavin 4
        //
        private void yavinCompleted(object sender, EventArgs e)
        {
            txtEndor.AppendText("Yavin 4 Crash.\n");
            yavinzone = null;
            Thread AnhRestart = new Thread(new ThreadStart(RestartANH));
            if (flgRestartAnh == true)
            {
                AnhRestart.Abort();
                flgRestartAnh = false;
            }
            AnhRestart.Start();
        }
        private void yavinCanceled(object sender, EventArgs e)
        {
            txtYavin.AppendText("Yavin 4 Stopped by user.\n");
            yavinzone = null;
        }

        //
        //Process The zoneserver output
        //
        private void writeTutorialStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtTutorial.AppendText(e.Text + Environment.NewLine);
        }
        private void writeTatooineStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtTatooine.AppendText(e.Text + Environment.NewLine);
        }
        private void writeCorelliaStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtCorellia.AppendText(e.Text + Environment.NewLine);
        }
        private void writeDantooineStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtDantooine.AppendText(e.Text + Environment.NewLine);
        }
        private void writeDathomirStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtDathomir.AppendText(e.Text + Environment.NewLine);
        }
        private void writeEndorStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtEndor.AppendText(e.Text + Environment.NewLine);
        }
        private void writeLokStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtLok.AppendText(e.Text + Environment.NewLine);
        }
        private void writeNabooStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtNaboo.AppendText(e.Text + Environment.NewLine);
        }
        private void writeRoriStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtRori.AppendText(e.Text + Environment.NewLine);
        }
        private void writeTalusStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtTalus.AppendText(e.Text + Environment.NewLine);
        }
        private void writeYavinStreamInfo(object sender, ProcessCallerLibrary.DataReceivedEventArgs e)
        {
            txtYavin.AppendText(e.Text + Environment.NewLine);
        }

        private void StartAnh()
        {
            conserver();
            Thread.Sleep(5000);
            chtserver();
            Thread.Sleep(5000);
            pngserver();
            Thread.Sleep(5000);
            logserver();
            //zones
            Thread.Sleep(10000);
            zonetutorial();
            Thread.Sleep(30000);
            zonetatooine();
            Thread.Sleep(20000);
            zonenaboo();
            Thread.Sleep(20000);
            zonecorellia();
            //Thread.Sleep(20000);
            //zonedantooine();
            //Thread.Sleep(20000);
            //zonedathomir();
            //Thread.Sleep(20000);
            //zoneendor();
            //Thread.Sleep(20000);
            //zonelok();
            //Thread.Sleep(20000);
            //zonenaboo();
            //Thread.Sleep(20000);
            //zonerori();
            //Thread.Sleep(20000);
            //zonetalus();
            //Thread.Sleep(20000);
            //zoneyavin();
            flgStartAnh = true;
        }
        private void RestartANH()
        {
            if (connectionserver != null)
            {
                connectionserver.Cancel();
            }
            if (chatserver != null)
            {
                chatserver.Cancel();
            }
            if (pingserver != null)
            {
                pingserver.Cancel();
            }
            if (loginserver != null)
            {
                loginserver.Cancel();
            }
            if (tutorialzone != null)
            {
                tutorialzone.Cancel();
            }
            if (tatooinezone != null)
            {
                tatooinezone.Cancel();
            }
            if (corelliazone != null)
            {
                corelliazone.Cancel();
            }
            if (dantooinezone != null)
            {
                dantooinezone.Cancel();
            }
            if (dathomirzone != null)
            {
                dathomirzone.Cancel();
            }
            if (endorzone != null)
            {
                endorzone.Cancel();
            }
            if (lokzone != null)
            {
                lokzone.Cancel();
            }
            if (naboozone != null)
            {
                naboozone.Cancel();
            }
            if (rorizone != null)
            {
                rorizone.Cancel();
            }
            if (taluszone != null)
            {
                taluszone.Cancel();
            }
            if (yavinzone != null)
            {
                yavinzone.Cancel();
            }

            conserver();
            Thread.Sleep(5000);
            chtserver();
            Thread.Sleep(5000);
            pngserver();
            Thread.Sleep(5000);
            logserver();
            //zones
            Thread.Sleep(10000);
            zonetutorial();
            Thread.Sleep(30000);
            zonetatooine();
            Thread.Sleep(20000);
            zonenaboo();
            Thread.Sleep(20000);
            zonecorellia();
            //Thread.Sleep(20000);
            //zonedantooine();
            //Thread.Sleep(20000);
            //zonedathomir();
            //Thread.Sleep(20000);
            //zoneendor();
            //Thread.Sleep(20000);
            //zonelok();
            //Thread.Sleep(20000);
            //zonenaboo();
            //Thread.Sleep(20000);
            //zonerori();
            //Thread.Sleep(20000);
            //zonetalus();
            //Thread.Sleep(20000);
            //zoneyavin();
            flgRestartAnh = true;
        }
        private void StopANH()
        {
            if (connectionserver != null)
            {
                connectionserver.Cancel();
            }
            if (chatserver != null)
            {
                chatserver.Cancel();
            }
            if (pingserver != null)
            {
                pingserver.Cancel();
            }
            if (loginserver != null)
            {
                loginserver.Cancel();
            }
            if (tutorialzone != null)
            {
                tutorialzone.Cancel();
            }
            if (tatooinezone != null)
            {
                tatooinezone.Cancel();
            }
            if (corelliazone != null)
            {
                corelliazone.Cancel();
            }
            if (dantooinezone != null)
            {
                dantooinezone.Cancel();
            }
            if (dathomirzone != null)
            {
                dathomirzone.Cancel();
            }
            if (endorzone != null)
            {
                endorzone.Cancel();
            }
            if (lokzone != null)
            {
                lokzone.Cancel();
            }
            if (naboozone != null)
            {
                naboozone.Cancel();
            }
            if (rorizone != null)
            {
                rorizone.Cancel();
            }
            if (taluszone != null)
            {
                taluszone.Cancel();
            }
            if (yavinzone != null)
            {
                yavinzone.Cancel();
            }

            flgStopAnh = true;
        }
        public void StartServer() {
            TcpListener tcpListener = new TcpListener(port);
            tcpListener.Start();
            //this.label1.Text = "Server Started";
            SetText("Started Server");

            //Timer t = new Timer(ComputeBoundOp, 5, 0, 2000); 
            //Creates an infinate loop that just listens for client connections.
            while (true)
            {
                //When a client connects create a socket for it.
                Socket socketForClient = tcpListener.AcceptSocket();
                try
                {
                    if (socketForClient.Connected)
                    {

                        string ipadd1 = socketForClient.RemoteEndPoint.ToString();
                        string[] ipaddy = ipadd1.Split(':');
                        Console.WriteLine("Client connected from " + ipaddy[0] + ":" + ipaddy[1] + "");
                        NetworkStream networkStream = new NetworkStream(socketForClient);
                        StreamWriter streamWriter = new StreamWriter(networkStream);
                        StreamReader streamReader = new StreamReader(networkStream);
                        string line = streamReader.ReadLine();

                        string[] logininfo = line.Split(',');
                        if (logininfo[0] == "start" && logininfo[2] == passkey)
                        {
                            if (logininfo[1] == "utilities")
                            {
                                //Console.WriteLine("Starting Up " + logininfo[1] + " Server...");
                                SetText("Starting Up " + logininfo[1] + " Server...");
                                Thread StartANH = new Thread(new ThreadStart(StartAnh));
                                if (flgStartAnh == true)
                                {
                                    StartANH.Abort();
                                    flgStartAnh = false;
                                }
                                StartANH.Start();
                                streamWriter.WriteLine("success");
                                //Console.WriteLine("Updated IP Info for " + logininfo[0] + "...");
                                streamWriter.Flush();
                                socketForClient.Close();
                                //

                            }                                                   
                        }
                        else if (logininfo[0] == "stop" && logininfo[2] == passkey)
                        {
                            Thread AnhStop = new Thread(new ThreadStart(StopANH));
                            if (flgStopAnh == true)
                            {
                                AnhStop.Abort();
                                flgStopAnh = false;
                            }
                            AnhStop.Start();
                            streamWriter.WriteLine("success");
                                
                                streamWriter.Flush();
                                socketForClient.Close();                           
                        }
                        else if (logininfo[0] == "status" && logininfo[2] == passkey)
                        {
                            if (logininfo[1] == "zones")
                            {
                                if (tutorialzone != null && tatooinezone != null && naboozone != null && corelliazone != null)
                                {
                                    streamWriter.WriteLine("success");

                                    streamWriter.Flush();
                                    socketForClient.Close();
                                }
                                else
                                {
                                    streamWriter.WriteLine("fail");

                                    streamWriter.Flush();
                                    socketForClient.Close();
                                }
                            }
                            if (logininfo[1] == "utilities")
                            {
                                if (connectionserver != null && chatserver != null && pingserver != null && loginserver != null)
                                {
                                    streamWriter.WriteLine("success");

                                    streamWriter.Flush();
                                    socketForClient.Close();
                                }
                                else
                                {
                                    streamWriter.WriteLine("fail");

                                    streamWriter.Flush();
                                    socketForClient.Close();
                                }
                            }
                            else if (logininfo[0] == "status" && logininfo[2] != passkey)
                            {
                               
                                        streamWriter.WriteLine("fail");

                                        streamWriter.Flush();
                                        socketForClient.Close();
                                    
                                }
                            else if (logininfo[0] == "stop" && logininfo[2] != passkey)
                            {

                                streamWriter.WriteLine("fail");

                                streamWriter.Flush();
                                socketForClient.Close();

                            }
                            else if (logininfo[0] == "start" && logininfo[2] != passkey)
                            {

                                streamWriter.WriteLine("fail");

                                streamWriter.Flush();
                                socketForClient.Close();

                            }
                            }
                        }
                    }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    //check if client socket is connected, if so close it.
                    if (socketForClient.Connected)
                        socketForClient.Close();
                }
                flgThreadRunning = true;
            }

            Console.WriteLine("Exiting...");
        }

        private void frmMonitor_Load(object sender, EventArgs e)
        {
            Thread serverStart = new Thread(new ThreadStart(StartServer));
            if (flgThreadRunning == false)
            {
                serverStart.Start();
            }
        }
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }
        }

        private void frmMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectionserver != null)
            {
                connectionserver.Cancel();
            }
            if (chatserver != null)
            {
                chatserver.Cancel();
            }
            if (pingserver != null)
            {
                pingserver.Cancel();
            }
            if (loginserver != null)
            {
                loginserver.Cancel();
            }
            if (tutorialzone != null)
            {
                tutorialzone.Cancel();
            }
            if (tatooinezone != null)
            {
                tatooinezone.Cancel();
            }
            if (corelliazone != null)
            {
                corelliazone.Cancel();
            }
            if (dantooinezone != null)
            {
                dantooinezone.Cancel();
            }
            if (dathomirzone != null)
            {
                dathomirzone.Cancel();
            }
            if (endorzone != null)
            {
                endorzone.Cancel();
            }
            if (lokzone != null)
            {
                lokzone.Cancel();
            }
            if (naboozone != null)
            {
                naboozone.Cancel();
            }
            if (rorizone != null)
            {
                rorizone.Cancel();
            }
            if (taluszone != null)
            {
                taluszone.Cancel();
            }
            if (yavinzone != null)
            {
                yavinzone.Cancel();
            }
            Process[] processes = Process.GetProcessesByName("AnhGui");

            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

    }
}
