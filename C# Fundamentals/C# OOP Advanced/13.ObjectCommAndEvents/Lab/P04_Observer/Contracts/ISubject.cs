namespace P04_Observer.Contracts
{
    public interface ISubject
    {
        void Register(IObserver observer);

        void Unregister(IObserver observer);

        void NotifyObservers();
    }
}
