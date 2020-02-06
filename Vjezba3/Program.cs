//using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vjezba3.Models;
using Vjezba3.ComponentRegister;


namespace Vjezba3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dependency.Initialize();

            var driver = Dependency.For<IDriversRepository>();
            var newDriver = new Driver
            {
                Id = 1,
                Name = "mariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomariomario",
                Surname = "zagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagarzagar",
                Money = 999999999999999999
            };

            try
            {
                driver.Create(newDriver);
                driver.Get(newDriver);
                driver.Exists(newDriver);
                driver.Delete(newDriver);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
