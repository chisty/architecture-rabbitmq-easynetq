using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using EasyNetQ;

namespace Publisher
{
    public class Process
    {
        public void Publish()
        {
            while (true)
            {
                var line= System.Console.ReadLine();
                if (line.StartsWith("e")) break;


                if (int.TryParse(line, out var n))
                {
                    var input = CreateInput(n);
                    using (var bus = RabbitHutch.CreateBus("host=localhost;username=chisty;password=chisty"))
                    {
                        bus.Publish<IPrimeInput>(input, input.Topic);
                    }
                }
            }
        }

        private IPrimeInput CreateInput(int n)
        {
            if (n % 2 == 0) return new EvenPrimeInput {N = n, Text = "EVEN prime input.", Topic = "prime.even"};
            return new OddPrimeInput() { N = n, Text = "ODD prime input.", Topic = "prime.odd" };
        }
    }
}
