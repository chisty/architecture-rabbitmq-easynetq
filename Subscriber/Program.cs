using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Main. Current AppDomain= "+AppDomain.CurrentDomain.FriendlyName);
            Thread.CurrentThread.Name = "Main Thread";

            //var domainService = IocContainer.Instance.Resolve<DomainService>();
            //domainService.Process();

            HostFactory.Run(x =>
            {
                x.Service<DomainService>();
                x.RunAsLocalSystem();
                x.SetDescription("Test Description: Chisty");
                x.SetDisplayName("Test Display: Chisty");
                x.SetServiceName("Test Service: Chisty");
                x.StartAutomatically();
            });
        }
    }
}
