using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba2.Models
{
    public interface IDriversRepository
    {
        Task<IEnumerable<Driver>> GetAll();
        Task<Driver> Get(int id);
        Task<bool> Create(Driver driver);
        Task<bool> Update(Driver driver);
        Task<bool> Exists(int id);
        Task<bool> Delete(int id);
    }
}
