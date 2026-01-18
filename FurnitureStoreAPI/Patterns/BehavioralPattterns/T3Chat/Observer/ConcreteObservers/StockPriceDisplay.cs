using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.ConcreteObservers
{
    // Concrete Observer 1: Stock Price Display
    public class StockPriceDisplay : IStockObserver
    {
        public string InvestorName { get; set; }
        private List<string> _updates = new();

        public StockPriceDisplay(string investorName)
        {
            InvestorName = investorName;
            Logger.GetInstance().Log(
                $"Observer: StockPriceDisplay " +
                $"'{investorName}' created");
        }

        public void Update(
            string stockSymbol,
            decimal previousPrice,
            decimal currentPrice)
        {
            decimal change = currentPrice - previousPrice;
            decimal percentChange =
                (change / previousPrice) * 100;

            string updateMessage =
                $"[{InvestorName}] {stockSymbol}: " +
                $"${previousPrice} → ${currentPrice} " +
                $"({percentChange:+0.00;-0.00}%)";

            _updates.Add(updateMessage);

            Logger.GetInstance().Log(
                $"Observer: {updateMessage}");

            Console.WriteLine($"📊 {updateMessage}");
        }

        public string GetObserverName()
        {
            return $"StockPriceDisplay-{InvestorName}";
        }

        public List<string> GetAllUpdates()
        {
            return new List<string>(_updates);
        }
    }
}
