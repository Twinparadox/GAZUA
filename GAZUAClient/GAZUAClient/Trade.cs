using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAZUAClient
{
    class Trade
    {
        private int stockIdx;
        private int numStock;
        private int flag;

        public int StockIdx { get => stockIdx; set => stockIdx = value; }
        public int NumStock { get => numStock; set => numStock = value; }
        public int Flag { get => flag; set => flag = value; }
    }
}
