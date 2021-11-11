public interface IObservable
{
    void Subscribe(IObserver obs);
    void UnSubscribe(IObserver obs);
    void NotifyToObservers(string action);
}
