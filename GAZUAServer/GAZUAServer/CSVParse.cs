﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Read CSV File and Make List of class Stock
 * 
 */
namespace GAZUAServer
{
    static class CSVParse
    {
        // Date,Open,High,Low,Close,Adj Close,Volume
        public static string path;
        public static int period;
        public static List<string> fileList;
       
        public static List<Stock> ReadCSVFile()
        {
            List<Stock> sList = new List<Stock>();

            path = "./stockdata/";
            string strFile = path + "SAMSUNG_Electronics.csv";

            using (FileStream fs = new FileStream(strFile, FileMode.Open))
            {
                List<int> price = new List<int>();
                List<int> volume = new List<int>();
                using(StreamReader sr = new StreamReader(fs, Encoding.UTF8, false))
                {
                    string strLineValue = null;

                    while((strLineValue = sr.ReadLine()) != null)
                    {
                        // structure of csv file from Yahoo Finance
                        // Date,Open,High,Low,Close,Adj Close, Volume
                        if (string.IsNullOrEmpty(strLineValue))
                            break;
                        string[] data = strLineValue.Split(',');

                        int p = (int)(Double.Parse(data[4]));
                        int vol = (int)(Double.Parse(data[6]));

                        price.Add(p);
                        volume.Add(vol);
                    }
                }
                sList.Add(new Stock("삼성전자", price, volume, 300));
            }
            return sList;
        }
    }
}