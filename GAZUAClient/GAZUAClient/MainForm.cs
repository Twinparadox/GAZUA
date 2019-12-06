using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZUAClient
{
    public partial class MainForm : Form
    {
        delegate void ActivateButtonDelegate(Control ctrl, int flag);
        ActivateButtonDelegate _buttonActivator;
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        delegate void UpdateStockDelegate(Control ctrl, List<Stock> list);
        UpdateStockDelegate _stockUpdater;
        delegate void DrawChartDelegate(Control ctrl, int idx);
        DrawChartDelegate _chartDrawer;
        delegate void UpdateInfoTBDelegate(Control ctrl, UserData user);
        UpdateInfoTBDelegate _infoTBUpdater;
        delegate void UpdateInfoLVDeleagte(Control ctrl, UserData user);
        UpdateInfoLVDeleagte _infoLVUpdater;

        Socket mainSock;
        IPAddress defaultAddress;

        string message = string.Empty;

        private UserData user = null;
        private bool isConnected = false;
        public static int BUFFERSIZE = 65536;
        public static int INIT_MONEY = 0;

        private int gameState;

        private int turn;
        private int startTurn;
        private int selectedStock;
        private List<Stock> stockList = null;
        private List<Trade> tradeList = null;
        private List<UserData> ranking = null;

        internal UserData User { get => user; set => user = value; }
        public bool IsConnected { get => isConnected; set => isConnected = value; }
        public int GameState { get => gameState; set => gameState = value; }
        public int Turn { get => turn; set => turn = value; }
        public int StartTurn { get => startTurn; set => startTurn = value; }
        public int SelectedStock { get => selectedStock; set => selectedStock = value; }
        internal List<Stock> StockList { get => stockList; set => stockList = value; }
        internal List<Trade> TradeList { get => tradeList; set => tradeList = value; }
      
        public MainForm()
        {
            InitializeComponent();

            TradeList = new List<Trade>();
            
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _buttonActivator = new ActivateButtonDelegate(ActivateButton);
            _textAppender = new AppendTextDelegate(AppendText);
            _stockUpdater = new UpdateStockDelegate(UpdateStock);
            _chartDrawer = new DrawChartDelegate(DrawChart);
            _infoTBUpdater = new UpdateInfoTBDelegate(UpdateInfoTB);
            _infoLVUpdater = new UpdateInfoLVDeleagte(UpdateInfoLV);
        }

        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());

            defaultAddress = IPAddress.Loopback;
            User = new UserData();

            btnTurnOver.Enabled = false;
            btnRanking.Enabled = false;
            tcTrade.Enabled = false;
        }

        private void ActivateButton(Control ctrl, int flag)
        {
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(_buttonActivator, ctrl, flag);
            }
            else
            {
                if(flag==1)
                {
                    ctrl.Enabled = true;
                }
                else
                {
                    ctrl.Enabled = false;
                }
            }
        }

        private void AppendText(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(_textAppender, ctrl, s);
            }
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }

        private void UpdateStock(Control ctrl, List<Stock> list)
        {
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(_stockUpdater, ctrl, list);
            }
            else
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
        }

        private void DrawChart(Control ctrl, int idx)
        {
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(_chartDrawer, ctrl, idx);
            }
            else
            {
                DrawLineChart(idx);
            }
        }

        private void UpdateInfoTB(Control ctrl, UserData user)
        {
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(_infoTBUpdater, ctrl, user);
            }
            else
            {
                if (ctrl.Equals(tbAssets))
                {
                    tbAssets.Text = user.UserAsset.ToString();
                }
                else if (ctrl.Equals(tbMoney))
                {
                    tbMoney.Text = user.UserMoney.ToString();
                }
                else
                {
                    float earning = (float)(user.UserAsset - INIT_MONEY) / INIT_MONEY;
                    tbEarningRate.Text = (earning * 100).ToString("N3");
                }
            }
        }

        private void UpdateInfoLV(Control ctrl, UserData user)
        {
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(_infoLVUpdater, ctrl, user);
            }
            else
            {
                lvMyState.BeginUpdate();
                lvMyState.Items.Clear();

                foreach(var stock in user.UserOwnStocks)
                {
                    ListViewItem lvItem = new ListViewItem(stock.StockIdx.ToString());
                    int curPrice = StockList[stock.StockIdx].Price;
                    float averPrice = stock.AverPrice;
                    int numStock = stock.NumStock;
                    int value = curPrice * numStock;
                    float earning = value - (averPrice * numStock);
                    float earningRate = earning / (averPrice * numStock) * 100;

                    lvItem.SubItems.Add(stock.StockName);
                    lvItem.SubItems.Add(curPrice.ToString());
                    lvItem.SubItems.Add(averPrice.ToString("N2"));
                    lvItem.SubItems.Add(numStock.ToString());
                    lvItem.SubItems.Add(value.ToString());
                    lvItem.SubItems.Add(earningRate.ToString("N3"));

                    lvMyState.Items.Add(lvItem);
                }

                lvMyState.EndUpdate();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        #endregion

        #region Socket Programming
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (mainSock.Connected)
            {
                MsgBoxHelper.Error("이미 연결되어 있습니다!");
                return;
            }

            int port;
            if (!int.TryParse(tbPort.Text, out port))
            {
                MsgBoxHelper.Error("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
                tbPort.Focus();
                tbPort.SelectAll();
                return;
            }

            try
            {
                mainSock.Connect(defaultAddress, port);

                // 서버 ip 주소와 메세지를 담도록 만든다.
                IPEndPoint ip = (IPEndPoint)mainSock.LocalEndPoint;

                var json = new JObject();
                json.Add("msgcode", 1);
                json.Add("NickName", tbNickName.Text);
                
                byte[] buffer = Encoding.UTF8.GetBytes(json.ToString());
                
                // 서버에 전송한다.
                mainSock.Send(buffer);

                User.UserNickName = tbNickName.Text;
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error("연결에 실패했습니다!\n오류 내용: {0}", MessageBoxButtons.OK, ex.Message);
                return;
            }

            // 연결 완료되었다는 메세지를 띄워준다.
            // AppendText(txtHistory, "서버와 연결되었습니다.");

            // 연결 완료, 서버에서 데이터가 올 수 있으므로 수신 대기한다.
            AsyncObject obj = new AsyncObject(BUFFERSIZE);
            obj.WorkingSocket = mainSock;
            mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
        }

        void DataReceived(IAsyncResult ar)
        {
            // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            // 데이터 수신을 끝낸다.
            int received = obj.WorkingSocket.EndReceive(ar);

            // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
            if (received <= 0)
            {
                obj.WorkingSocket.Close();
                return;
            }

            // 텍스트로 변환한다.
            string message = Encoding.UTF8.GetString(obj.Buffer);

            var json = JObject.Parse(message);

            var msgType = json["msgcode"];

            int strType = Int32.Parse(msgType.ToString());

            // Init
            if (strType == 1)
            {
                var msgInitMoney = json["initmoney"];
                var msgData = json["StockList"];
                StockList = JsonConvert.DeserializeObject<List<Stock>>(msgData.ToString());

                User.UserMoney = Int32.Parse(msgInitMoney.ToString());
                INIT_MONEY = Int32.Parse(msgInitMoney.ToString());
                ActivateButton(btnConnect, 2);
                foreach (var item in StockList)
                {
                    item.StartDate = 0;
                }
                UpdateStock(lvStockState, StockList);
                UpdateInfo();
            }

            // Start
            else if (strType == 2)
            {
                var msgData = json["StockList"];
                StockList = JsonConvert.DeserializeObject<List<Stock>>(msgData.ToString());

                ActivateButton(btnTurnOver, 1);
                ActivateButton(btnRanking, 1);
                ActivateButton(tcTrade, 1);
                foreach (var item in StockList)
                {
                    item.StartDate = 0;
                }
                UpdateStock(lvStockState, StockList);
                UpdateInfo();
            }

            // Playing
            else if (strType == 3)
            {
                var msgData = json["StockList"];
                StockList = JsonConvert.DeserializeObject<List<Stock>>(msgData.ToString());

                ActivateButton(btnTurnOver, 1);
                ActivateButton(btnRanking, 1);
                ActivateButton(tcTrade, 1);
                foreach (var item in StockList)
                {
                    item.StartDate = 0;
                }
                UpdateStock(lvStockState, StockList);
                UpdateInfo();
            }

            // Ranking
            else if (strType == 4)
            {
                var msgData = json["ranklist"];
                ranking = JsonConvert.DeserializeObject<List<UserData>>(msgData.ToString());

                int idx = 1;
                foreach (var user in ranking)
                {
                    if (user.UserNickName.Equals(User.UserNickName))
                    {
                        break;
                    }
                    idx++;
                }

                int count = ranking.Count();
                MsgBoxHelper.Info("당신의 순위\n" + count.ToString() + "명 중\n" + idx.ToString() + "위");
            }

            // End Game, strType == 5
            else
            {
                ActivateButton(btnTurnOver, 0);
                ActivateButton(btnRanking, 1);
                ActivateButton(tcTrade, 0);

                var msgData = json["ranklist"];
                ranking = JsonConvert.DeserializeObject<List<UserData>>(msgData.ToString());

                int idx = 1;
                foreach(var user in ranking)
                {
                    if(user.UserNickName.Equals(User.UserNickName))
                    {
                        break;
                    }
                    idx++;
                }

                if(idx == 1)
                {
                    MsgBoxHelper.Info("우승하였습니다.");
                }
                else if(idx == 2)
                {
                    MsgBoxHelper.Info("준우승하였습니다.");
                }
                else
                {
                    MsgBoxHelper.Info("당신의 순위는 " + idx.ToString() + "위입니다.");
                }
            }

            // 텍스트박스에 추가해준다.
            // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
            // 따라서 대리자를 통해 처리한다.
            // AppendText(txtHistory, string.Format("[받음]{0}: {1}", ip, msg));

            // 클라이언트에선 데이터를 전달해줄 필요가 없으므로 바로 수신 대기한다.
            // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
            obj.ClearBuffer();

            // 수신 대기
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, BUFFERSIZE, 0, DataReceived, obj);
        }

        void OnSendData(object sender, EventArgs e)
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 보낼 텍스트
            string tts = "HELLO";
            if (string.IsNullOrEmpty(tts))
            {
                MsgBoxHelper.Warn("텍스트가 입력되지 않았습니다!");
                return;
            }

            // 서버 ip 주소와 메세지를 담도록 만든다.
            IPEndPoint ip = (IPEndPoint)mainSock.LocalEndPoint;
            string addr = ip.Address.ToString();

            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] bDts = Encoding.UTF8.GetBytes(addr + '\x01' + tts);

            // 서버에 전송한다.
            mainSock.Send(bDts);
        }
        #endregion

        private void btnTurnOver_Click(object sender, EventArgs e)
        {
            btnTurnOver.Enabled = false;
            tcTrade.Enabled = false;
            
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            var json = new JObject();
            json.Add("msgcode", 3);
            json.Add("userdata", JsonConvert.SerializeObject(User));

            var json1 = JsonConvert.SerializeObject(User.UserOwnStocks);
            var json1str = json1.ToString();
            json.Add("userowns", JArray.Parse(json1str));

            string strJson = json.ToString();
            
            // 서버 ip 주소와 메세지를 담도록 만든다.
            IPEndPoint ip = (IPEndPoint)mainSock.LocalEndPoint;
            string addr = ip.Address.ToString();

            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] buffer = Encoding.UTF8.GetBytes(strJson);

            // 서버에 전송한다.
            mainSock.Send(buffer);

            TradeList.Clear();
        }

        private void btnMaxBuy_Click(object sender, EventArgs e)
        {
            int n = 0;

            int userMoney = User.UserMoney;
            n = userMoney / Int32.Parse(tbBuyPrice.Text);
 
            tbBuy.Text = n.ToString();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            Trade t = new Trade();

            t.StockIdx = SelectedStock;
            t.NumStock = Int32.Parse(tbBuy.Text);
            t.Flag = 1;

            TradeList.Add(t);

            User.BuyStock(SelectedStock, StockList[SelectedStock].Name, Int32.Parse(tbBuy.Text), StockList[SelectedStock].Price);
            UpdateInfo();
        }

        private void btnMaxSell_Click(object sender, EventArgs e)
        {
            int n = 0;
            bool flag = false;

            // 보유 주식 있는지 없는지 확인
            if(User.HasStock(selectedStock) == -1)
            {
                MsgBoxHelper.Info("보유 주식이 없습니다!");
                tbSell.Text = "0";
            }
            else
            {
                foreach(var owns in User.UserOwnStocks)
                {
                    if(owns.StockIdx == SelectedStock)
                    {
                        n = owns.NumStock;
                        break;
                    }
                }
                tbSell.Text = n.ToString();
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            Trade t = new Trade();

            t.StockIdx = SelectedStock;
            t.NumStock = Int32.Parse(tbSell.Text);
            t.Flag = 2;

            TradeList.Add(t);
            User.SellStock(SelectedStock, StockList[SelectedStock].Name, Int32.Parse(tbSell.Text), StockList[SelectedStock].Price);
            UpdateInfo();
        }

        public void UpdateData()
        {

        }

        #region ListViewStockState
        private void lvStockState_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 특정 종목을 더블클릭하면 그래프를 그려줌
            if (lvStockState.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = lvStockState.SelectedItems;
                ListViewItem lvItem = items[0];

                try
                {
                    int stockIdx = Int32.Parse(lvItem.SubItems[0].Text);
                    DrawChart(chartStock, stockIdx);

                    tbBuyPrice.Text = tbSellPrice.Text = stockList[stockIdx].PriceList.Last().ToString();
                    SelectedStock = stockIdx;
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
            chartStock.ChartAreas[0].AxisX.Minimum = 0;

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

        #region NewTurn
        private void UpdateInfo()
        {
            foreach(var owns in User.UserOwnStocks)
            {
                owns.CurPrice = StockList[owns.StockIdx].Price;
            }

            UpdateInfoTB(tbMoney, User);
            UpdateInfoTB(tbAssets, User);
            UpdateInfoTB(tbEarningRate, User);

            UpdateInfoLV(lvMyState, User);
        }
        #endregion

        #region Ranking Button
        private void btnRanking_Click(object sender, EventArgs e)
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            var json = new JObject();
            json.Add("msgcode", 4);
            json.Add("nickname", User.UserNickName);

            string strJson = json.ToString();

            // 서버 ip 주소와 메세지를 담도록 만든다.
            IPEndPoint ip = (IPEndPoint)mainSock.LocalEndPoint;
            string addr = ip.Address.ToString();

            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] buffer = Encoding.UTF8.GetBytes(strJson);

            // 서버에 전송한다.
            mainSock.Send(buffer);
        }
        #endregion

    }
}
