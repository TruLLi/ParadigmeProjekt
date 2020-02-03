using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba1.Models
{
    public class Driver
    {
        public int Money { get; set; }

        public IWinMoney WinMoney;


        public Driver(IWinMoney winMoney)
        {
            this.WinMoney = winMoney;
        }


        public int MakingMoney()
        {
            return WinMoney.WinMoney();
        }


        public void Withdraw(int amount)
        {
            if (amount <= Money)
                Money -= amount;
        }


        protected virtual int RandomNumber()
        {
            return new Random().Next(0, 2);
        }


        public CrashMove RandomCrashMove()
        {
            var random = RandomNumber();
            var crashmove = new CrashMove[]
            {
                new Truck(),
                new Car(),
                new Motorcycle()
            };

            return crashmove[random];
        }


        public CrashMove MakeCrashMove(string crashMoveName)
        {
            if (string.IsNullOrEmpty(crashMoveName))
                throw new Exception();
            var crashMoveDictionary = new Dictionary<string, CrashMove>
            {
                {"Truck", new Truck()},
                {"Car", new Car() },
                {"Motorcycle", new Motorcycle() }
            };

            CrashMove crashMove;
            crashMove = crashMoveDictionary[crashMoveName];

            return crashMove;
        }


    }
}
