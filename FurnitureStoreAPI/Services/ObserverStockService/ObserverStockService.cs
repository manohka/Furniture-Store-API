using FurnitureStoreAPI.Models.T3ChatObserver;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.ConcreteObservers;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.ConcreteSubject;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Services.ObserverStockService
{
    public class ObserverStockService
    {
        private Dictionary<string, Stock> _stocks = new();
        private Dictionary<string, IStockObserver>
            _observers = new();

        public void CreateStock(
            string symbol,
            string companyName,
            decimal initialPrice)
        {
            if (_stocks.ContainsKey(symbol))
            {
                throw new InvalidOperationException(
                    $"Stock {symbol} already exists");
            }

            var stock = new Stock(
                symbol,
                companyName,
                initialPrice);
            _stocks[symbol] = stock;

            Logger.GetInstance().Log(
                $"Service: Created stock {symbol}");
        }

        public StockResponse AttachObserver(
            AttachObserverRequest request)
        {
            if (!_stocks.ContainsKey(request.StockSymbol))
            {
                throw new KeyNotFoundException(
                    $"Stock {request.StockSymbol} not found");
            }

            var stock = _stocks[request.StockSymbol];

            IStockObserver observer =
                request.ObserverType.ToLower() switch
                {
                    "pricedisplay" =>
                        new StockPriceDisplay(
                            request.InvestorName),
                    "alert" =>
                        new StockAlertNotifier(
                            request.InvestorName,
                            request.AlertThreshold ?? 5m),
                    "portfolio" =>
                        new PortfolioTracker(
                            request.InvestorName,
                            request.SharesOwned ?? 0,
                            stock.GetCurrentPrice()),
                    _ => throw new ArgumentException(
                        "Unknown observer type")
                };

            string observerKey =
                $"{request.StockSymbol}-" +
                $"{observer.GetObserverName()}";
            _observers[observerKey] = observer;

            stock.Attach(observer); // IMPORTANT STEP HERE

            Logger.GetInstance().Log(
                $"Service: Attached observer " +
                $"{observer.GetObserverName()} " +
                $"to {request.StockSymbol}");

            return GetStockResponse(stock);
        }

        public StockResponse DetachObserver(
            string stockSymbol,
            string observerName)
        {
            if (!_stocks.ContainsKey(stockSymbol))
            {
                throw new KeyNotFoundException(
                    $"Stock {stockSymbol} not found");
            }

            var stock = _stocks[stockSymbol];

            var observer = _observers.Values
                .FirstOrDefault(o =>
                    o.GetObserverName()
                    .Contains(observerName));

            if ( observer != null)
            {
                stock.Detach(observer);

                var keyToRemove = _observers
                    .FirstOrDefault(kvp => kvp.Value == observer).Key;

                if ( keyToRemove != null )
                {
                    _observers.Remove(keyToRemove);
                }

                Logger.GetInstance().Log(
                    $"Service: Detached observer " +
                    $"{observerName} from {stockSymbol}");
            }
            return GetStockResponse(stock);
        }

        private StockResponse GetStockResponse(Stock stock)
        {
            return new StockResponse
            {
                Symbol = stock.GetStockSymbol(),
                CompanyName = stock.CompanyName,
                CurrentPrice = stock.GetCurrentPrice(),
                ObserverCount = stock.GetObserverCount(),
                Observers = stock.GetObserverNames()
            };
        }

        public StockPriceUpdateResponse UpdateStockPrice(
            string stockSymbol,
            decimal newPrice)
        {
            if (!_stocks.ContainsKey(stockSymbol))
            {
                throw new KeyNotFoundException(
                    $"Stock {stockSymbol} not found");
            }

            var stock = _stocks[stockSymbol];

            decimal previousPrice = stock.GetCurrentPrice();

            stock.SetPrice( newPrice );

            decimal change = newPrice - previousPrice;
            decimal percentChange =
                (change / previousPrice) * 100;

            return new StockPriceUpdateResponse
            {
                StockSymbol = stockSymbol,
                PreviousPrice = previousPrice,
                NewPrice = newPrice,
                Change = change,
                PercentChange = percentChange,
                NotifiedObservers = stock
                    .GetObserverCount(),
                Message =
                    $"Stock {stockSymbol} updated. " +
                    $"{stock.GetObserverCount()} " +
                    $"observers notified."
            };
        }

        public StockResponse GetStock(string symbol)
        {
            if (!_stocks.ContainsKey(symbol))
            {
                throw new KeyNotFoundException(
                    $"Stock {symbol} not found");
            }

            return GetStockResponse(_stocks[symbol]);
        }

        public List<StockResponse> GetAllStocks()
        {
            return _stocks.Values
                .Select(GetStockResponse)
                .ToList();
        }

    }
}
