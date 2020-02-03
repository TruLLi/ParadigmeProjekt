using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba1.Models
{
    public class FakeMoney : IWinMoney
    {
        public int WinMoney() { return 0; }
    }

    public class AddMoney : IWinMoney
    {
        public int _amount;
        public AddMoney(int ammount)
        {
            _amount = ammount;
        }
        public int WinMoney()
        {
            return _amount;
        }
    }
}
