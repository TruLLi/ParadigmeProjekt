using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba2.Models
{
    public class DriverContext : DbContext
    {
        public DriverContext(DbContextOptions<DriverContext> options) : base(options) { }

        public DbSet<Driver> Driver { get; set; }
    }
}
