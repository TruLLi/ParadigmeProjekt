using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba1.Models
{
    public abstract class CrashMove
    {
        public int Victory(CrashMove crashMove)
        {
            if (crashMove is Car)
                return Victory(crashMove as Car);
            else if (crashMove is Motorcycle)
                return Victory(crashMove as Motorcycle);
            else if (crashMove is Truck)
                return Victory(crashMove as Truck);
            return -2;
        }

        public abstract int Victory(Car car);
        public abstract int Victory(Motorcycle motorcycle);
        public abstract int Victory(Truck truck);

    }
}
