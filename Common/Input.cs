using System;

namespace Common
{
    public class EvenPrimeInput: IPrimeInput
    {
        
        public string Text { get; set; }
        public int N { get; set; }
        public string Topic { get; set; }
    }

    public class OddPrimeInput : IPrimeInput
    {
        public string Text { get; set; }
        public int N { get; set; }
        public string Topic { get; set; }
    }

    public interface IPrimeInput
    {
        int N { get; set; }
        string Topic { get; set; }
    }
}
