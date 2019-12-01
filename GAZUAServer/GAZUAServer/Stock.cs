﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAZUAServer
{
    class Stock
    {
        private string name;
        private List<int> priceList;
        private List<int> volumeList;
        private int turn;
        private int nTurns;
        private int startDate;
        
        public string Name { get => name; set => name = value; }
        public int Turn { get => turn; set => turn = value; }
        public int StartDate { get => startDate; set => startDate = value; }

        public List<int> PriceList
        {
            get { return priceList.GetRange(StartDate, 30); }
            set { priceList = value; }
        }
        public List<int> VolumeList
        {
            get { return volumeList.GetRange(StartDate, 30); }
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
