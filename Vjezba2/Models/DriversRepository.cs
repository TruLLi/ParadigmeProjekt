using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba2.Models
{
    public class DriversRepository : IDriversRepository
    {
        private readonly DriverContext context;
        public DriversRepository(DriverContext context) => this.context = context;

        public async Task<bool> Create(Driver driver)
        {
            if (driver == null)
                throw new System.ArgumentNullException(nameof(driver));
            await context.Driver.AddAsync(driver);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Driver> Get(int id) => await context.Driver.FindAsync(id);

        public async Task<IEnumerable<Driver>> GetAll() => await context.Driver.ToListAsync();

        public async Task<bool> Update(Driver driver)
        {
            if (driver == null)
                throw new System.ArgumentNullException(nameof(driver));
            if (driver.Id <= 0)
                return false;
            context.Entry(driver).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public Task<bool> Exists(int id) => context.Driver.AnyAsync(e => e.Id == id);

        public async Task<bool> Delete(int id)
        {
            var driver = await Get(id);
            if (driver == null)
                return false;
            context.Driver.Remove(driver);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
