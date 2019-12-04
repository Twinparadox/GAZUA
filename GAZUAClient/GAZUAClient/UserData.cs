using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAZUAClient
{
    class UserData
    {
        public class OwnStock
        {
            private int stockIdx;
            private string stockName;
            private int numStock;
            private float averPrice;
            private int curPrice;

            public int StockIdx { get => stockIdx; set => stockIdx = value; }
            public string StockName { get => stockName; set => stockName = value; }
            public int NumStock { get => numStock; set => numStock = value; }
            public float AverPrice { get => averPrice; set => averPrice = value; }
            public int Sum { get => (int)(curPrice * numStock); }
            public int CurPrice { get => curPrice; set => curPrice = value; }

            public OwnStock(int idx, string name)
            {
                stockIdx = idx;
                stockName = name;
                numStock = 0;
                averPrice = 0;
            }

            public void BuyStock(int num, int price)
            {
                int sum = (int)(NumStock * AverPrice);

                sum += num * price;
                numStock += num;

                averPrice = (float)sum / num;
            }

            public int SellStock(int num, int price)
            {
                numStock -= num;
                return num * price;
            }
        }

        private string userNickName;
        private int userMoney;
        private List<OwnStock> userOwnStocks;
        private int isReady;

        public string UserNickName { get => userNickName; set => userNickName = value; }
        public int UserMoney { get => userMoney; set => userMoney = value; }
        public List<OwnStock> UserOwnStocks { get => userOwnStocks; set => userOwnStocks = value; }

        public int UserStocks
        {
            get
            {
                int sum = 0;

                foreach (var owns in UserOwnStocks)
                {
                    sum += owns.Sum;
                }

                return sum;
            }
        }
        public int UserAsset
        {
            get
            {
                int sum = UserMoney;

                foreach (var owns in UserOwnStocks)
                {
                    sum += owns.Sum;
                }

                return sum;
            }
        }

        public int IsReady { get => isReady; set => isReady = value; }

        public UserData()
        {
            UserOwnStocks = new List<OwnStock>();
            IsReady = 0;
        }

        public UserData(string nickname, int money)
        {
            UserNickName = nickname;
            UserMoney = money;
            UserOwnStocks = new List<OwnStock>();
            IsReady = 0;
        }

        public int HasStock(int stockIdx)
        {
            int n = -1;

            foreach(var stock in UserOwnStocks)
            {
                if (stock.StockIdx == stockIdx)
                {
                    n = stock.NumStock;
                    break;
                }
            }

            return n;
        }

        public void BuyStock(int stockIdx, string stockName, int nStock, int price)
        {
            int idx = 0;
            bool flag = false;

            foreach (var own in UserOwnStocks)
            {
                if (own.StockIdx == stockIdx)
                {
                    flag = true;
                    break;
                }
                idx++;
            }

            if (flag)
            {
                UserOwnStocks[idx].BuyStock(nStock, price);
                UserMoney -= nStock * price;
            }
            else
            {
                OwnStock own = new OwnStock(stockIdx, stockName);
                own.BuyStock(nStock, price);
                UserMoney -= nStock * price;

                UserOwnStocks.Add(own);
            }
        }

        public void SellStock(int stockIdx, string stockName, int nStock, int price)
        {
            int idx = 0;
            bool flag = false;

            foreach (var own in UserOwnStocks)
            {
                if (own.StockIdx == stockIdx)
                {
                    flag = true;
                    break;
                }
                idx++;
            }

            if (flag)
            {
                UserMoney += UserOwnStocks[idx].SellStock(nStock, price);

                // 더 이상 주식을 소유하고 있지 않은 경우 제거
                if(UserOwnStocks[idx].NumStock == 0)
                {
                    UserOwnStocks.RemoveAt(idx);
                }
            }
        }
    }
}
