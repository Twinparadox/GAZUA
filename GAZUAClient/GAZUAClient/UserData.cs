using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAZUAClient
{
    class UserData
    {
        private int asset;
        private int money;
        private List<UserStock> stockList = null; 

        public int Asset { get => asset; set => asset = value; }
        public int Money { get => money; set => money = value; }

        public UserData()
        {

        }
    }
}
