using System;
using System.ComponentModel.Composition;
using Common;
using EasyNetQ;

namespace Subscriber.Subscribers
{
    [Export(typeof(IPrimeSubscriber))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PrimeSubscriber: APrimeGenerator, IPrimeSubscriber
    {
        public void DoProcess(IBus messageBus)
        {                        
            messageBus.Subscribe<IPrimeInput>("prime", Handler, x => x.WithTopic("prime.*"));            
        }

        private void Handler(IPrimeInput input)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("PrimeSubscriber");

            var prime = GetPrime(input.N);
            if (input is EvenPrimeInput evenInput)
            {
                Console.WriteLine(evenInput.Text);
            }
            else
            {
                Console.WriteLine(((OddPrimeInput)input).Text);
            }
            Console.WriteLine("Prime= " + prime); Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}