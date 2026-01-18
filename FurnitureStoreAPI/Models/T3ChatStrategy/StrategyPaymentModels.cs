namespace FurnitureStoreAPI.Models.T3ChatStrategy
{
    /*public class StrategyPaymentModels
    {
    }*/

    public class ProcessPaymentRequest
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentDetails { get; set; }
        public string CustomerName { get; set; }
    }

    public class PaymentResponse
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime ProcessedAt { get; set; }
        public string Message { get; set; }
    }

    public class PaymentMethodInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public decimal FeePercentage { get; set; }
    }

    public class ValidatePaymentRequest
    {
        public string PaymentMethod { get; set; }
        public string PaymentDetails { get; set; }
    }

    public class ValidatePaymentResponse
    {
        public bool IsValid { get; set; }
        public string PaymentMethod { get; set; }
        public string Message { get; set; }
    }
}
