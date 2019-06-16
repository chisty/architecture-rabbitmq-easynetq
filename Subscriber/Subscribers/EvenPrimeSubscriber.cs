using Common;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Subscribers
{
    [Export(typeof(IPrimeSubscriber))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EvenPrimeSubscriber: APrimeGenerator, IPrimeSubscriber
    {
        public void DoProcess(IBus messageBus)
        {
            messageBus.Subscribe<IPrimeInput>("even-prime", Handler, x => x.WithTopic("prime.even"));
        }

        private void Handler(IPrimeInput input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("EvenPrimeSubscriber");

            var prime = GetPrime(input.N);
            if (input is EvenPrimeInput evenInput)
            {
                Console.WriteLine(evenInput.Text);
            }
            else
            {
                Console.WriteLine("Error Input");
            }
            Console.WriteLine("Prime= " + prime); Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
