using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAZUAClient
{
    class Stock
    {
        private string name;
        private List<int> priceList;
        private List<int> volumeList;
        private int turn;
        private int nTurns;
        private int startDate;
        private static int term;

        public string Name { get => name; set => name = value; }
        public int Turn { get => turn; set => turn = value; }
        public int StartDate { get => startDate; set => startDate = value; }

        public int Price
        {
            get { return priceList[term + Turn - 1]; }
        }
        public List<int> PriceList
        {
            get { return priceList.GetRange(StartDate, term + Turn); }
            set { priceList = value; }
        }
        public List<int> VolumeList
        {
            get { return volumeList.GetRange(StartDate, term + Turn); }
            set { volumeList = value; }
        }
        public int NTurns { get => nTurns; set => nTurns = value; }

        public Stock(string name, List<int> priceList, List<int> volumeList, int start, int nTurns)
        {
            Name = name;
            PriceList = priceList;
            VolumeList = volumeList;
            Turn = 0;
            StartDate = start;
            term = 30;
            NTurns = nTurns;
        }

        public int GetPrice(int date)
        {
            return priceList[date];
        }

        public List<int> GetPrices(int start, int end)
        {
            int count = end - start;
            return priceList.GetRange(start, count);
        }

        public int GetVolume(int date)
        {
            return priceList[date];
        }

        public List<int> GetVolumes(int start, int end)
        {
            int count = end - start;
            return volumeList.GetRange(start, count);
        }
    }
}
