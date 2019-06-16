using EasyNetQ;

namespace Subscriber
{
    public interface IPrimeSubscriber
    {
        void DoProcess(IBus messageBus);
        //void DoProcess();
    }
}