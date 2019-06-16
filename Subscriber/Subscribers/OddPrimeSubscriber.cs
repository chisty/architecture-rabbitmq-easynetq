using Common;
using EasyNetQ;
using System;
using System.ComponentModel.Composition;

namespace Subscriber.Subscribers
{
    [Export(typeof(IPrimeSubscriber))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OddPrimeSubscriber: APrimeGenerator, IPrimeSubscriber
    {
        public void DoProcess(IBus messageBus)
        {
            messageBus.Subscribe<IPrimeInput>("odd-prime", Handler, x => x.WithTopic("prime.odd"));            
        }

        private void Handler(IPrimeInput input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OddPrimeSubscriber");

            var prime = GetPrime(input.N);
            if (input is OddPrimeInput oddInput)
            {
                Console.WriteLine(oddInput.Text);
            }
            else
            {
                Console.WriteLine("Error Input");
            }
            Console.WriteLine("Prime= " + prime);  Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}