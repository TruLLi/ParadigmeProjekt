using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vjezba3.Interceptors;
using Vjezba3.Models;

namespace Vjezba3.ComponentRegister
{
    public class ComponentRegistration : IRegistration
    {
        public void Register(IKernelInternal kernel)
        {
            kernel.Register(
                Component.For<LoggingInterceptor>()
                    .ImplementedBy<LoggingInterceptor>());

            kernel.Register(
                Component.For<IDriversRepository>()
                         .ImplementedBy<DriversRepository>()
                         .Interceptors(InterceptorReference.ForType<LoggingInterceptor>()).Anywhere);
        }
    }
}
