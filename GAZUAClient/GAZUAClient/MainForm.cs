using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZUAClient
{
    public partial class MainForm : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        Thread t_handler = null;

        string message = string.Empty;

        private UserData user = null;
        private bool isConnected = false;
        public static int BUFFERSIZE = 65536;

        internal UserData User { get => user; set => user = value; }
        public bool IsConnected { get => isConnected; set => isConnected = value; }

        public MainForm()
        {
            InitializeComponent();
        }

        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            User = new UserData();

            btnTurnOver.Enabled = false;
            btnRanking.Enabled = false;
            tcTrade.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientSocket.Close();
            t_handler.Abort();
        }
        #endregion

        #region Socket Programming
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect("localhost", Int32.Parse(tbPort.Text));
                stream = clientSocket.GetStream();

                message = "Connected to Chat Server";

                byte[] buffer = Encoding.Unicode.GetBytes(this.tbNickName.Text + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

                btnConnect.Enabled = false;
                tcTrade.Enabled = true;
                btnMaxSell.Enabled = false;
                btnMaxBuy.Enabled = false;
                btnSell.Enabled = false;
                btnBuy.Enabled = false;

                t_handler = new Thread(GetMessage);
                t_handler.IsBackground = true;
                t_handler.Start();

                SendInit();
            }
            catch(Exception ex)
            {
                Trace.WriteLine(string.Format("btnConnect_Click - Exception : {0}", ex.Message));
            }
        }

        private void SendInit()
        {
            byte[] buffer = Encoding.Unicode.GetBytes("User Connected" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush(); 
        }

        private void SendData(string data)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(data + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
        private void GetMessage()
        {
            while (true)
            {
                stream = clientSocket.GetStream();
                int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[BUFFERSIZE];

                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.Unicode.GetString(buffer, 0, bytes);

                /*
                if (buffer.Length != 0)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        btnTurnOver.Enabled = true;
                        tcTrade.Enabled = true;
                    }));
                }
                */
            }
        }

        private void tbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 입력된 문자가 제어 문자 혹은 10진수 문자일 경우엔 입력을 허용하고
            // 그 외의 문자가 입력된 경우 입력을 차단한다.
            // 괄호 앞의 느낌표(!)는 bool 값을 반대로 하라는 것이다.
            // 따라서 아래 코드는 다음 코드와 동일하다.
            // 1. e.Handled = (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) == false;
            // 2. e.Handled = char.IsControl(e.KeyChar) == false && char.IsDigit(e.KeyChar) == false;
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
        }
        #endregion

        private void btnTurnOver_Click(object sender, EventArgs e)
        {
            btnTurnOver.Enabled = false;
            tcTrade.Enabled = false;
        }

        private void btnMaxBuy_Click(object sender, EventArgs e)
        {

        }

        private void btnMaxSell_Click(object sender, EventArgs e)
        {

        }

        public void UpdateData()
        {

        }

        /*
        #region Line Chart
        public void DrawLineChart(int stockIdx)
        {
            // Draw Line Chart
            // Click ListView Item or ..

            Stock selectedStock = stockList[stockIdx];
            List<int> priceList = selectedStock.PriceList;

            int minPrice = priceList.Min();
            int maxPrice = priceList.Max();

            int minChart = CalculateThreshold(minPrice, 1);

            chartStock.Series[0].Points.Clear();
            chartStock.ChartAreas[0].AxisY.Minimum = minChart;
            chartStock.ChartAreas[0].AxisX.Minimum = Turn;

            for (int i = 0; i < priceList.Capacity; i++)
            {
                chartStock.Series[0].Points.AddXY(i, priceList[i]);
            }
        }

        private void CalculateCounter()
        {
        }

        public int CalculateThreshold(int price, int flag)
        {
            int comp = 1;
            while (comp < price)
            {
                comp *= 10;
            }

            comp /= 10;
            float thPrice = (int)((float)price / comp);
            thPrice *= comp;

            if (flag == 1)
            {
                return (int)thPrice;
            }
            else
            {
                return (int)thPrice;
            }
        }
        #endregion
        */
    }
}
