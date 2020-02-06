using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba3.Models
{
    class DriversRepository : IDriversRepository
    {
        public void Create(Driver driver)
        {
            Console.WriteLine("Create {0}", driver);
        }

        public void Delete(Driver driver)
        {
            Console.WriteLine("Deleting {0}", driver);
        }

        public void Exists(Driver driver)
        {
            Console.WriteLine("Exists {0}", driver);
        }

        public void Get(Driver driver)
        {
            Console.WriteLine("Get {0}", driver);
        }

        public IEnumerable<Driver> GetAll()
        {
            Console.WriteLine("Getting drivers");
            return null;
        }

        public void Update(Driver driver)
        {
            Console.WriteLine("Updating {0}", driver);

        }
    }
}
