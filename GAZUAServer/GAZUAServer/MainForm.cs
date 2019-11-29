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

        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            StockList = CSVParse.ReadCSVFile();
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
        #endregion

        #region ListViewStockState
        public void UpdateListViewStockState()
        {
            lvStockState.BeginUpdate();

            int idx = 0;
            foreach(Stock stock in StockList)
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

            for (int i = 0; i < priceList.Capacity; i++)
            {
                chartStock.Series[0].Points.AddXY(i, priceList[i]);
            }
        }

        private void CalculateCounter()
        {
            counter--;
        }

        public int CalculateThreshold(int price, int flag)
        {
            int comp = 1;
            while(comp<price)
            {
                comp *= 10;
            }

            comp /= 10;
            float thPrice = (int)((float)price / comp);
            thPrice *= comp;

            if(flag == 1)
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
    }
}
