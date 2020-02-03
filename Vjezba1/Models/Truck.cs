using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba1.Models
{
    public class Truck : CrashMove
    {
        public override int Victory(Car car)
        {
            return 1;
        }
        public override int Victory(Motorcycle motorcycle)
        {
            return -1;
        }
        public override int Victory(Truck truck)
        {
            return 0;
        }

    }
}
