using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZUAServer
{
    public partial class MainForm : Form
    {
        TcpListener server = null;
        TcpClient clientSocket = null;
        Thread t = null;

        private Dictionary<TcpClient, UserData> clientList = new Dictionary<TcpClient, UserData>();

        private static int counter;
        public static int startTurn = 200;
        public static int nTurns = 50;
        public static int PortNum = 5000;

        public static int StartMoney = 10000000;

        private int gameState;

        private int turn;
        private List<Stock> stockList = null;

        public int Counter { get => counter; set => counter = value; }
        public int GameState { get => gameState; set => gameState = value; }
        public int Turn { get => turn; set => turn = value; }
        internal List<Stock> StockList { get => stockList; set => stockList = value; }
        internal Dictionary<TcpClient, UserData> ClientList { get => clientList; set => clientList = value; }

        public MainForm()
        {
            InitializeComponent();
        }

        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            Turn = 0;

            StockList = CSVParse.ReadCSVFile(startTurn, nTurns);
            DrawLineChart(0);

            UpdateListViewStockState();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #region Socket Programming        
        private void btnListen_Click(object sender, EventArgs e)
        {
            // socket start
            t = new Thread(InitSocket);
            t.IsBackground = true;
            t.Start();
            btnListen.Enabled = false;
            btnGameStart.Enabled = true;
            btnClose.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            t.Abort();
            btnClose.Enabled = false;
            btnGameStart.Enabled = false;
            btnListen.Enabled = true;
        }

        private void InitSocket()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, PortNum);
                clientSocket = default(TcpClient);
                server.Start();
                UpdateServerState(">> Server Started");

                while (true)
                {
                    try
                    {
                        counter++;
                        clientSocket = server.AcceptTcpClient();
                        UpdateServerState(">> Accept connection from client");

                        NetworkStream stream = clientSocket.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytes = stream.Read(buffer, 0, buffer.Length);
                        string user_name = Encoding.Unicode.GetString(buffer, 0, bytes);
                        user_name = user_name.Substring(0, user_name.IndexOf("$"));

                        ClientList.Add(clientSocket, new UserData(user_name, StartMoney));

                        // send message all user
                        //SendMessageAll(user_name + " Joined ", "", false);

                        handleClient h_client = new handleClient();
                        h_client.OnReceived += new handleClient.MessageDisplayHandler(OnReceived);
                        h_client.OnDisconnected += new handleClient.DisconnectedHandler(h_client_OnDisconnected);
                        h_client.startClient(clientSocket, ClientList);
                        SendInitMessage(clientSocket);
                    }
                    catch (SocketException se)
                    {
                        Trace.WriteLine(string.Format("InitSocket - SocketException : {0}", se.Message));
                        break;
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(string.Format("InitSocket - Exception : {0}", ex.Message));
                        break;
                    }
                }

                if (clientSocket != null)
                {
                    clientSocket.Close();
                }
                server.Stop();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("InitSocket - Exception : {0}", ex.Message));
            }
        }

        void h_client_OnDisconnected(TcpClient clientSocket)
        {
            if (ClientList.ContainsKey(clientSocket))
                ClientList.Remove(clientSocket);
        }

        private void OnReceived(string message, string user_name)
        {
            // 여기서 클라이언트의 닉네임을 수신받자.
            string displayMessage = "From client : " + user_name + " : " + message;
            UpdateServerState(displayMessage);
            UpdateListViewUserState();
            SendMessageAll(message, user_name, true);
        }

        public void SendMessageAll(string message, string user_name, bool flag)
        {
            // 여기서 주식 데이터와 클라이언트 개인의 정보를 뿌려주자.
            foreach (var pair in ClientList)
            {
                Trace.WriteLine(string.Format("tcpclient : {0} user_name : {1}", pair.Key, pair.Value.UserNickName));

                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;

                if (flag)
                {
                    buffer = Encoding.Unicode.GetBytes(user_name + " says : " + message);
                }
                else
                {
                    buffer = Encoding.Unicode.GetBytes(message);
                }

                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        public void SendInitMessage(TcpClient client)
        {
            // 최초 메세지 전송
            // 초기화된 데이터 전송
            Trace.WriteLine(string.Format("[InitMessage] tcpclient : {0}", client));

            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = null;

                string json = JsonConvert.SerializeObject(StockList[0]);

                buffer = Encoding.Unicode.GetBytes(json);
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
        #endregion

        #region ListViewUserState
        public void UpdateUserState()
        {
            if(lvUserState.InvokeRequired)
            {
                lvUserState.BeginInvoke(new MethodInvoker(delegate
                {
                    UpdateListViewUserState();
                }));
            }
            else
            {
                UpdateListViewUserState();
            }
        }
        public void UpdateListViewUserState()
        {
            lvUserState.BeginUpdate();
            lvUserState.Items.Clear();

            int idx = 0;
            foreach (var client in clientList)
            {
                UserData user = client.Value;

                ListViewItem lvItem = new ListViewItem(idx.ToString());
                lvItem.SubItems.Add(user.UserNickName);
                lvItem.SubItems.Add(user.UserMoney.ToString());
                lvItem.SubItems.Add(user.UserStocks.ToString());
                lvItem.SubItems.Add(user.UserAsset.ToString());
                
                if(user.IsReady == 1)
                {
                    lvItem.SubItems.Add("Wait");
                }
                else if(user.IsReady == 2)
                {
                    lvItem.SubItems.Add("On");
                }
                else
                {
                    lvItem.SubItems.Add("Off");
                }

                lvUserState.Items.Add(lvItem);
                idx++;
            }
            lvUserState.EndUpdate();
        }
        #endregion

        #region ListViewStockState
        public void UpdateStockState()
        {
            if (lvStockState.InvokeRequired)
            {
                lvStockState.BeginInvoke(new MethodInvoker(delegate
                {
                    UpdateListViewStockState();
                }));
            }
            else
            {
                UpdateListViewStockState();
            }
        }
        public void UpdateListViewStockState()
        {
            lvStockState.BeginUpdate();
            lvStockState.Items.Clear();

            int idx = 0;
            foreach (Stock stock in StockList)
            {
                List<int> priceList = stock.PriceList;
                int count = priceList.Count;
                int curPrice = priceList.Last();
                int prevPrice = priceList.ElementAt(count - 2);

                int sub = curPrice - prevPrice;
                float subRatio = (float)sub / prevPrice * 100;

                int minPrice = priceList.Min();
                int maxPrice = priceList.Max();

                ListViewItem lvItem = new ListViewItem(idx.ToString());
                lvItem.SubItems.Add(stock.Name);
                lvItem.SubItems.Add(curPrice.ToString());
                lvItem.SubItems.Add(sub.ToString());
                lvItem.SubItems.Add(subRatio.ToString("N2"));
                lvItem.SubItems.Add(maxPrice.ToString());
                lvItem.SubItems.Add(minPrice.ToString());
                lvStockState.Items.Add(lvItem);
                idx++;
            }

            lvStockState.EndUpdate();
        }

        private void lvStockState_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 특정 종목을 더블클릭하면 그래프를 그려줌
            if (lvStockState.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = lvStockState.SelectedItems;
                ListViewItem lvItem = items[0];

                try
                {
                    DrawLineChart(Int32.Parse(lvItem.SubItems[0].Text));
                }
                catch
                {
                    MessageBox.Show("Error Drawing Chart");
                }
            }
        }
        #endregion

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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void lvStockState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Game Start
        private void btnGameStart_Click(object sender, EventArgs e)
        {
            UpdateListViewUserState();

        }
        #endregion

        #region Turn Over
        private void TurnOver()
        {

        }
        #endregion
    }
}
