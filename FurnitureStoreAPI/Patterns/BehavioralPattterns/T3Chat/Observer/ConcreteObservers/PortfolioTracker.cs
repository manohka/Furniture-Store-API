using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Observer.ConcreteObservers
{
    // Concrete Observer 3: Portfolio Tracker
    public class PortfolioTracker : IStockObserver
    {
        public string InvestorName { get; set; }
        public int SharesOwned { get; set; }
        private decimal _totalPortfolioValue = 0;
        private List<string> _portfolioUpdates = new();

        public PortfolioTracker(
            string investorName,
            int sharesOwned,
            decimal initialPrice)
        {
            InvestorName = investorName;
            SharesOwned = sharesOwned;
            _totalPortfolioValue =
                sharesOwned * initialPrice;

            Logger.GetInstance().Log(
                $"Observer: PortfolioTracker " +
                $"'{investorName}' created " +
                $"(shares: {sharesOwned})");
        }

        public void Update(
            string stockSymbol,
            decimal previousPrice,
            decimal currentPrice)
        {
            decimal previousValue =
                SharesOwned * previousPrice;
            decimal currentValue =
                SharesOwned * currentPrice;
            decimal gainLoss =
                currentValue - previousValue;

            _totalPortfolioValue = currentValue;

            string updateMessage =
                $"💰 [{InvestorName}] Portfolio Update: " +
                $"{stockSymbol} × {SharesOwned} shares: " +
                $"${previousValue:F2} → ${currentValue:F2} " +
                $"({(gainLoss > 0 ? "+" : "")}{gainLoss:F2})";

            _portfolioUpdates.Add(updateMessage);

            Logger.GetInstance().Log(
                $"Observer: {updateMessage}");

            Console.WriteLine(updateMessage);
        }

        public string GetObserverName()
        {
            return $"PortfolioTracker-{InvestorName}";
        }

        public decimal GetPortfolioValue()
        {
            return _totalPortfolioValue;
        }

        public List<string> GetAllUpdates()
        {
            return new List<string>(_portfolioUpdates);
        }
    }
}
