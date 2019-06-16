using System;

namespace Subscriber.Subscribers
{
    public class APrimeGenerator
    {
        public int GetPrime(int n)
        {
            if (n == 1) return 2;
            if (n == 2) return 3;

            var count = 2;
            var number = 4;
            while (true)
            {
                if (IsPrime(number)) count++;
                if (count == n) return number;
                number++;
            }
        }

        private static bool IsPrime(int number)
        {
            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}