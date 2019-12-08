using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        delegate void ActivateButtonDelegate(Control ctrl, int flag);
        ActivateButtonDelegate _buttonActivator;
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        delegate void UpdateUserDelegate(Control ctrl, Dictionary<Socket, UserData> list);
        UpdateUserDelegate _userUpdater;
        delegate void UpdateRankingDelegate(Control ctrl, List<UserData> list);
        UpdateRankingDelegate _rankingUpdater;
        delegate void UpdateStockDelegate(Control ctrl, List<Stock> list);
        UpdateStockDelegate _stockUpdater;

        Socket mainSock;
        IPAddress thisAddress;

        private Dictionary<Socket, UserData> clientList;

        private static int counter;
        public static int startTurn = 200;
        public static int Term = 30;
        public static int nTurns = 10;
        public static int curTurn = 0;
        public static int PortNum = 5000;
        public static int BUFFERSIZE = 65536;
        public static int StartMoney = 10000000;

        private int gameState;

        private int restTurn;
        private List<Stock> stockList = null;

        public int Counter { get => counter; set => counter = value; }
        public int GameState { get => gameState; set => gameState = value; }
        public int RestTurn { get => restTurn; set => restTurn = value; }
        internal List<Stock> StockList { get => stockList; set => stockList = value; }
        internal Dictionary<Socket, UserData> ClientList { get => clientList; set => clientList = value; }

        public MainForm()
        {
            InitializeComponent();
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _buttonActivator = new ActivateButtonDelegate(ActivateButton);
            _textAppender = new AppendTextDelegate(AppendText);
            _userUpdater = new UpdateUserDelegate(UpdateUser);
            _rankingUpdater = new UpdateRankingDelegate(UpdateRanking);
            _stockUpdater = new UpdateStockDelegate(UpdateStock);

            ClientList = new Dictionary<Socket, UserData>();
        }

        private void ActivateButton(Control ctrl, int flag)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(_buttonActivator, ctrl, flag);
            }
            else
            {
                if (flag == 1)
                {
                    ctrl.Enabled = true;
                }
                else
                {
                    ctrl.Enabled = false;
                }
            }
        }

        void AppendText(Control ctrl, string s)
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

        void UpdateUser(Control ctrl, Dictionary<Socket, UserData> list)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(_userUpdater, ctrl, list);
            }
            else
            {
                foreach (var user in list)
                {
                    foreach (var owns in user.Value.UserOwnStocks)
                    {
                        owns.CurPrice = StockList[owns.StockIdx].Price;
                    }
                }

                lvUserState.BeginUpdate();
                lvUserState.Items.Clear();

                int idx = 0;
                foreach (var item in list)
                {
                    UserData user = item.Value;

                    ListViewItem lvItem = new ListViewItem(idx.ToString());
                    lvItem.SubItems.Add(user.UserNickName);
                    lvItem.SubItems.Add(user.UserMoney.ToString());
                    lvItem.SubItems.Add(user.UserStocks.ToString());
                    lvItem.SubItems.Add(user.UserAsset.ToString());

                    if (user.IsReady == 1)
                    {
                        lvItem.SubItems.Add("Doing");
                    }
                    else if (user.IsReady == 2)
                    {
                        lvItem.SubItems.Add("Done");
                    }
                    else
                    {
                        lvItem.SubItems.Add("Waiting");
                    }

                    lvUserState.Items.Add(lvItem);
                    idx++;
                }
                lvUserState.EndUpdate();
            }
        }

        void UpdateRanking(Control ctrl, List<UserData> list)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(_rankingUpdater, ctrl, list);
            }
            else
            {
                lvUserRanking.BeginUpdate();
                lvUserRanking.Items.Clear();

                int idx = 1;
                foreach(var user in list)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.SubItems.Add(idx.ToString());
                    lvItem.SubItems.Add(user.UserNickName);
                    lvItem.SubItems.Add(((float)(user.UserAsset)/1000).ToString("N2"));

                    lvUserRanking.Items.Add(lvItem);

                    idx++;
                }
                lvUserRanking.EndUpdate();
            }
        }

        void UpdateStock(Control ctrl, List<Stock> list)
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

        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            RestTurn = 0;

            StockList = CSVParse.ReadCSVFile(startTurn, nTurns);
            DrawLineChart(0);

            UpdateListViewStockState();

            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
            thisAddress = IPAddress.Loopback;
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
            // 서버에서 클라이언트의 연결 요청을 대기하기 위해
            // 소켓을 열어둔다.
            IPEndPoint serverEP = new IPEndPoint(thisAddress, PortNum);
            mainSock.Bind(serverEP);
            mainSock.Listen(10);

            // 비동기적으로 클라이언트의 연결 요청을 받는다.
            mainSock.BeginAccept(AcceptCallback, null);

            AppendText(rtbServerState, string.Format("서버가 열렸습니다."));

            btnListen.Enabled = false;
            btnClose.Enabled = true;
            btnGameStart.Enabled = true;
        }

        void AcceptCallback(IAsyncResult ar)
        {
            // 클라이언트의 연결 요청을 수락한다.
            Socket client = mainSock.EndAccept(ar);

            // 또 다른 클라이언트의 연결을 대기한다.
            mainSock.BeginAccept(AcceptCallback, null);

            AsyncObject obj = new AsyncObject(BUFFERSIZE);
            obj.WorkingSocket = client;

            // 연결된 클라이언트 리스트에 추가해준다.
            ClientList.Add(client, new UserData("5000", StartMoney));

            // 텍스트박스에 클라이언트가 연결되었다고 써준다.
            AppendText(rtbServerState, string.Format("클라이언트 (@ {0})가 연결되었습니다.", client.RemoteEndPoint));

            SendInitData();

            // 클라이언트의 데이터를 받는다.
            client.BeginReceive(obj.Buffer, 0, BUFFERSIZE, 0, DataReceived, obj);
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
                string msgData = json["NickName"].ToString();
                ClientList[obj.WorkingSocket].UserNickName = msgData;
                UpdateUser(lvUserState, ClientList);
            }

            // Playing - Turn Over
            else if(strType == 3)
            {
                var userData = json["userdata"];
                UserData user = JsonConvert.DeserializeObject<UserData>(userData.ToString());

                var ownsData = json["userowns"];
                user.UserOwnStocks = JsonConvert.DeserializeObject<List<UserData.OwnStock>>(ownsData.ToString());

                ClientList[obj.WorkingSocket] = user;
                ClientList[obj.WorkingSocket].IsReady = 2;
                UpdateUser(lvUserState, ClientList);

                int cnt = 0;
                int cnt_client = 0;
                foreach(var client in ClientList)
                {
                    cnt_client++;
                    if (client.Value.IsReady==2)
                    {
                        cnt++;
                    }
                }

                // 모든 유저가 턴을 마친 상태면, 다음 턴으로 진행
                if(cnt==cnt_client)
                {
                    NextTurn();
                }
            }

            // Playing - Ranking, strType == 4
            else
            {
                List<UserData> userList = new List<UserData>();

                foreach (var user in ClientList)
                {
                    userList.Add(user.Value);
                }
                userList = userList.OrderByDescending(x => x.UserAsset).ToList();

                SendRanking(obj.WorkingSocket, userList);
            }

            // 텍스트박스에 추가해준다.
            // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
            // 따라서 대리자를 통해 처리한다.

            // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
            obj.ClearBuffer();

            // 수신 대기
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, BUFFERSIZE, 0, DataReceived, obj);
        }

        void SendInitData()
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            byte[] buffer = null;

            var json = new JObject();
            json.Add("msgcode", 1);
            json.Add("initmoney", 10000000);

            var json1 = JsonConvert.SerializeObject(StockList);
            var json1str = json1.ToString();

            json.Add("StockList", JArray.Parse(json1str));

            string strJson = json.ToString();

            buffer = Encoding.UTF8.GetBytes(strJson);

            // 연결된 모든 클라이언트에게 전송한다.
            foreach (var client in ClientList)
            {
                Socket socket = client.Key;
                try { socket.Send(buffer); }
                catch
                {
                    // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                    try { socket.Dispose(); } catch { }
                }
            }
            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(rtbServerState, string.Format("초기 데이터 전송 완료"));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose.Enabled = false;
            btnGameStart.Enabled = false;
            btnListen.Enabled = true;
        }
        #endregion

        #region ListViewUserState
        #endregion

        #region ListViewStockState
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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void lvStockState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Game Start
        private void btnGameStart_Click(object sender, EventArgs e)
        {
            RestTurn = nTurns;
            curTurn = 1;
            SendStart();
            btnGameStart.Enabled = false;
            Ranking();
        }

        void SendStart()
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 보낼 텍스트
            byte[] buffer = null;

            var json = new JObject();
            json.Add("msgcode", 2);
            json.Add("restTurn", RestTurn);

            var json1 = JsonConvert.SerializeObject(StockList);
            var json1str = json1.ToString();

            json.Add("StockList", JArray.Parse(json1str));

            string strJson = json.ToString();

            buffer = Encoding.UTF8.GetBytes(strJson);

            // 연결된 모든 클라이언트에게 전송한다.
            foreach (var client in ClientList)
            {
                Socket socket = client.Key;
                try
                {
                    socket.Send(buffer);
                    client.Value.IsReady = 1;
                }
                catch
                {
                    // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                    try
                    {
                        socket.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(rtbServerState, string.Format("게임 시작, 남은 턴 : "+RestTurn.ToString()));
            UpdateUser(lvUserState, ClientList);
        }
        #endregion

        #region Game Playing
        private void btnNextTurn_Click(object sender, EventArgs e)
        {
            foreach(var user in ClientList)
            {
                if(user.Value.IsReady == 1)
                {
                    MsgBoxHelper.Error("아직 턴을 마치지 않은 유저가 있습니다.");
                    return;
                }
            }

            curTurn++;
            RestTurn--;
            
            if(RestTurn == 0)
            {
                ActivateButton(btnNextTurn, 0);
                ActivateButton(btnGameStart, 1);
                MsgBoxHelper.Info("턴 종료");
                EndGame();
                return;
            }

            foreach(var st in StockList)
            {
                st.Turn++;
            }

            SendStockMessage();

            UpdateStock(lvStockState, StockList);
            UpdateUser(lvUserState, ClientList);
            Ranking();

            AppendText(rtbServerState, string.Format("남은 턴 : " + RestTurn.ToString()));
        }

        private void NextTurn()
        {
            curTurn++;
            RestTurn--;

            if (RestTurn == 0)
            {
                ActivateButton(btnNextTurn, 0);
                ActivateButton(btnGameStart, 1);
                MsgBoxHelper.Info("턴 종료");
                EndGame();
                return;
            }

            foreach (var st in StockList)
            {
                st.Turn++;
            }

            SendStockMessage();

            UpdateStock(lvStockState, StockList);
            UpdateUser(lvUserState, ClientList);
            Ranking();

            AppendText(rtbServerState, string.Format("남은 턴 : " + RestTurn.ToString()));
        }

        public void SendStockMessage()
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            byte[] buffer = null;

            var json = new JObject();
            json.Add("msgcode", 3);

            var json1 = JsonConvert.SerializeObject(StockList);
            var json1str = json1.ToString();

            json.Add("StockList", JArray.Parse(json1str));

            string strJson = json.ToString();

            buffer = Encoding.UTF8.GetBytes(strJson);

            // 연결된 모든 클라이언트에게 전송한다.
            foreach (var client in ClientList)
            {
                Socket socket = client.Key;
                client.Value.IsReady = 1;
                try { socket.Send(buffer); }
                catch
                {
                    // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                    try { socket.Dispose(); } catch { }
                }
            }
            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(rtbServerState, string.Format("주식 데이터 전송 완료"));
        }
        #endregion

        #region End Game
        private void EndGame()
        {// 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 보낼 텍스트
            byte[] buffer = null;

            var json = new JObject();
            json.Add("msgcode", 5);
            
            List<UserData> userList = new List<UserData>();

            foreach (var user in ClientList)
            {
                userList.Add(user.Value);
            }

            userList = userList.OrderByDescending(x => x.UserAsset).ToList();
            UpdateRanking(lvUserRanking, userList);

            var json1 = JsonConvert.SerializeObject(userList);
            var json1str = json1.ToString();
            json.Add("ranklist", JArray.Parse(json1str));

            string strJson = json.ToString();

            buffer = Encoding.UTF8.GetBytes(strJson);

            // 연결된 모든 클라이언트에게 전송한다.
            foreach (var client in ClientList)
            {
                Socket socket = client.Key;
                try
                {
                    socket.Send(buffer);
                    client.Value.IsReady = 1;
                }
                catch
                {
                    // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                    try
                    {
                        socket.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(rtbServerState, string.Format("게임 종료"));
            UpdateUser(lvUserState, ClientList);
        }
        #endregion

        #region Ranking
        void Ranking()
        {
            List<UserData> userList = new List<UserData>();

            foreach(var user in ClientList)
            {
                userList.Add(user.Value);
            }
            UpdateRanking(lvUserRanking, userList.OrderByDescending(x => x.UserAsset).ToList());
        }

        private void SendRanking(Socket socket, List<UserData> list)
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            byte[] buffer = null;

            var json = new JObject();
            json.Add("msgcode", 4);
            
            var json1 = JsonConvert.SerializeObject(list);
            var json1str = json1.ToString();
            json.Add("ranklist", JArray.Parse(json1str));

            string strJson = json.ToString();
            buffer = Encoding.UTF8.GetBytes(strJson);

            try { socket.Send(buffer); }
            catch
            {
                // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                try { socket.Dispose(); } catch { }
            }
            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(rtbServerState, string.Format(ClientList[socket].UserNickName+"에게 랭킹 데이터 전송 완료"));
        }
        #endregion

        #region Turn Over
        #endregion
    }
}
