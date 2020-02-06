using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba3.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private Stopwatch stopwatch = new Stopwatch();
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            try
            {
                stopwatch.Start();
                Console.WriteLine(string.Format("Entered Method:{0}, Arguments: {1}", methodName, string.Join(",", invocation.Arguments)));
                invocation.Proceed();
                stopwatch.Stop();
                Console.WriteLine(string.Format("Sucessfully executed method:{0}, duration={1}", methodName, stopwatch.Elapsed));
                
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Method:{0}, Exception:{1}, duration={2}", methodName, e.Message, stopwatch.Elapsed));
                throw;
            }
            finally
            {
                Console.WriteLine(string.Format("Exiting Method:{0}, duration={1}", methodName, stopwatch.Elapsed));
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
        }
    }
}
