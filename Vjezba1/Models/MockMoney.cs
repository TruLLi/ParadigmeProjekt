using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba1.Models
{
    public class MockMoney : IWinMoney
    {
        public int _amount;
        public Dictionary<string, int> MethodCount = new Dictionary<string, int>();

        public MockMoney(int amount)
        {
            _amount = amount;
        }

        public void DecreaseOrIncrease(string method)
        {
            if (MethodCount.ContainsKey(method))
            {
                MethodCount[method]++;
            }
            else
            {
                MethodCount.Add(method, 1);
            }
        }
        public int WinMoney()
        {
            DecreaseOrIncrease(nameof(WinMoney));
            return _amount;
        }
    }
}
