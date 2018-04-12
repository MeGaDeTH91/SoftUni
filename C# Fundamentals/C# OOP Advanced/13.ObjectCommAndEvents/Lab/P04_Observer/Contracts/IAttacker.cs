using P04_Observer.Contracts;

public interface IAttacker : IObserver
{
    void Attack();

    void SetTarget(ITarget target);
}
