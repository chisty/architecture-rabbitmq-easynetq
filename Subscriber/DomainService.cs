using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Topshelf;

namespace Subscriber
{
    //[Export(typeof(DomainService))]
    //[PartCreationPolicy(CreationPolicy.NonShared)]
    public class DomainService: ServiceControl
    {
        //public void Process()
        //{
        //    var subscribers = IocContainer.Instance.ResolveAll<IPrimeSubscriber>();

        //    foreach (var subscriber in subscribers)
        //    {
        //        subscriber.DoProcess();
        //    }
        //}

        public bool Start(HostControl hostControl)
        {
            var subscribers = IocContainer.Instance.ResolveAll<IPrimeSubscriber>();

            //using (var bus = RabbitHutch.CreateBus("host=localhost;username=chisty;password=chisty"))
            //{
            //    foreach (var subscriber in subscribers)
            //    {
            //        subscriber.DoProcess(bus);
            //    }
            //}

            var bus = RabbitHutch.CreateBus("host=localhost;username=chisty;password=chisty");
            foreach (var subscriber in subscribers)
            {
                subscriber.DoProcess(bus);
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
