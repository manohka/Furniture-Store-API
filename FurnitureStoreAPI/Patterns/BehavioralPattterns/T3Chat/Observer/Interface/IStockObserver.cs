namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.Interface
{
    // Observer Interface
    public interface IStockObserver
    {
        void Update(
            string stockSymbol,
            decimal previousPrice,
            decimal currentPrice);

        string GetObserverName();
    }
}
