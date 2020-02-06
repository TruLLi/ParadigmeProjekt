using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba3.Models
{
    public interface IDriversRepository
    {
        void Get(Driver driver);
        void Create(Driver driver);
        void Delete(Driver driver);
        void Update(Driver driver);
        void Exists(Driver driver);
        IEnumerable<Driver> GetAll();
    }
}
