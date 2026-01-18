using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.Interface
{
    // Subject Interface (Observable)
    public interface IStockSubject
    {
        void Attach(IStockObserver observer);
        void Detach(IStockObserver observer);
        void Notify();
        string GetStockSymbol();
        decimal GetCurrentPrice();
    }
}

/*Key Observer Pattern Benefits:


 Loose Coupling - Stock doesn't know observer details

 Dynamic Subscriptions - Add/remove observers anytime

 Automatic Updates - All observers notified when price changes

 Single Responsibility - Each observer does one thing

 Reusability - Observers can work with multiple stocks

 Real-world - Used in event systems, messaging, notifications!*/