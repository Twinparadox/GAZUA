using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZUAServer
{
    public partial class MainForm : Form
    {
        TcpListener server = null;
        TcpClient client = null;
        static int counter = 0;

        private int portNum;

        private int turn;
        private List<Stock> stockList = null;

        public int Turn { get => turn; set => turn = value; }
        internal List<Stock> StockList { get => stockList; set => stockList = value; }

        public int PortNum { get => portNum; set => portNum = value; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StockList = CSVParse.ReadCSVFile();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitSocket()
        {
            server = new TcpListener(IPAddress.Any, 9999);
            client = default(TcpClient);
            server.Start();
            UpdateServerState(">> Server Started");

            while (true)
            {
                try
                {
                    counter++;
                    client = server.AcceptTcpClient();
                    UpdateServerState(">> Accept connection from client");

                    HandleClient h_client = new HandleClient();
                    h_client.OnReceived += new HandleClient.MessageDisplayHandler(UpdateServerState);
                    h_client.OnCalculated += new HandleClient.CalculateClientCounter(CalculateCounter);
                    h_client.startClient(client, counter);
                }
                catch (SocketException se)
                {
                    Trace.WriteLine(string.Format("InitSocket - SocketException : {0}", se.Message));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(string.Format("InitSocket - Exception : {0}", ex.Message));
                }
            }
        }

        public void UpdateServerState(string text)
        {
            if (rtbServerState.InvokeRequired)
            {
                rtbServerState.BeginInvoke(new MethodInvoker(delegate
                {
                    rtbServerState.AppendText(text + Environment.NewLine);
                }));
            }
            else
            {
                rtbServerState.AppendText(text + Environment.NewLine);
            }
        }

        private void CalculateCounter()
        {
            counter--;
        }
    }
}
