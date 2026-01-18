namespace FurnitureStoreAPI.Models.T3ChatObserver
{
    /*public class ObserverPatternModels
    {
    }*/

    public class AttachObserverRequest
    {
        public string StockSymbol { get; set; }
        public string ObserverType { get; set; }
        // "priceDisplay", "alert", "portfolio"
        public string InvestorName { get; set; }
        public decimal? AlertThreshold { get; set; }
        public int? SharesOwned { get; set; }
    }

    public class UpdateStockPriceRequest
    {
        public string StockSymbol { get; set; }
        public decimal NewPrice { get; set; }
    }

    public class StockResponse
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal CurrentPrice { get; set; }
        public int ObserverCount { get; set; }
        public List<string> Observers { get; set; }
    }

    public class ObserverUpdateResponse
    {
        public string Message { get; set; }
        public string StockSymbol { get; set; }
        public string ObserverName { get; set; }
    }

    public class StockPriceUpdateResponse
    {
        public string StockSymbol { get; set; }
        public decimal PreviousPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal Change { get; set; }
        public decimal PercentChange { get; set; }
        public int NotifiedObservers { get; set; }
        public string Message { get; set; }
    }
}
