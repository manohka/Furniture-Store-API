using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.ConcreteObservers
{
    // Concrete Observer 2: Stock Alert Notifier
    public class StockAlertNotifier : IStockObserver
    {
        public string InvestorName { get; set; }
        public decimal AlertThreshold { get; set; }
        private List<string> _alerts = new();

        public StockAlertNotifier(
            string investorName,
            decimal alertThreshold)
        {
            InvestorName = investorName;
            AlertThreshold = alertThreshold;
            Logger.GetInstance().Log(
                $"Observer: StockAlertNotifier " +
                $"'{investorName}' created " +
                $"(threshold: {alertThreshold}%)");
        }

        public void Update(
            string stockSymbol,
            decimal previousPrice,
            decimal currentPrice)
        {
            decimal percentChange =
                ((currentPrice - previousPrice) /
                previousPrice) * 100;

            if (Math.Abs(percentChange) >= AlertThreshold)
            {
                string alertMessage =
                    $"🚨 ALERT [{InvestorName}]: " +
                    $"{stockSymbol} changed by " +
                    $"{percentChange:+0.00;-0.00}% " +
                    $"(threshold: {AlertThreshold}%)";

                _alerts.Add(alertMessage);

                Logger.GetInstance().Log(
                    $"Observer: {alertMessage}");

                Console.WriteLine(alertMessage);
            }
        }

        public string GetObserverName()
        {
            return $"StockAlertNotifier-{InvestorName}";
        }

        public List<string> GetAllAlerts()
        {
            return new List<string>(_alerts);
        }
    }
}
