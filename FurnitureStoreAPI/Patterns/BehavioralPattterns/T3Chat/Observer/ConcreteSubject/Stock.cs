using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.ConcreteSubject
{
    // Concrete Subject: Stock
    public class Stock : IStockSubject
    {

        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        private decimal _price;
        private decimal _previousPrice;

        private List<IStockObserver> _observers = new List<IStockObserver>();

        public Stock(string symbol,
            string companyName,
            decimal initialPrice)
        {
            Symbol = symbol;
            CompanyName = companyName;
            _price = initialPrice;
            _previousPrice = initialPrice;

            Logger.GetInstance().Log(
                $"Observer: Stock '{symbol}' created " +
                $"at ${initialPrice}");
        }

        // Subject: Attach observer
        public void Attach(IStockObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                Logger.GetInstance().Log(
                    $"Observer: {observer.GetObserverName()} " +
                    $"attached to {Symbol}");
            }
        }

        // Subject: Detach observer
        public void Detach(IStockObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
                Logger.GetInstance().Log(
                    $"Observer: {observer.GetObserverName()} " +
                    $"detached from {Symbol}");
            }
        }

        // Subject: Notify all observers
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(Symbol,
                    _previousPrice,
                    _price);
            }
        }

        // Change price and notify observers
        public void SetPrice(decimal newPrice)
        {
            if (newPrice != _price)
            {
                _previousPrice = _price;
                _price = newPrice;

                Logger.GetInstance().Log(
                    $"Observer: {Symbol} price changed " +
                    $"from ${_previousPrice} to ${_price}. " +
                    $"Notifying {_observers.Count} observers");

                Notify();
            }
        }

        public string GetStockSymbol()
        {
            return Symbol;
        }

        public decimal GetCurrentPrice()
        {
            return _price;
        }

        public int GetObserverCount()
        {
            return _observers.Count;
        }

        public List<string> GetObserverNames()
        {
            return _observers
                .Select(o => o.GetObserverName())
                .ToList();
        }
    }
}
