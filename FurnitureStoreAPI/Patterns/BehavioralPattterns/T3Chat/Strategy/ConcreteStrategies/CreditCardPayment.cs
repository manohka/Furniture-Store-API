using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Strategy.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Strategy.ConcreteStrategies
{
    // Concrete Strategy 1: Credit Card Payment
    public class CreditCardPayment : IPaymentStrategy
    {
        public bool ValidatePayment(
            string paymentDetails)
        {
            // Validate credit card format
            // Format: XXXX-XXXX-XXXX-XXXX
            if (string.IsNullOrEmpty(paymentDetails))
                return false;

            var parts = paymentDetails.Split('-');
            if (parts.Length != 4)
                return false;

            foreach (var part in parts)
            {
                if (part.Length != 4 ||
                    !part.All(char.IsDigit))
                    return false;
            }

            Logger.GetInstance().Log(
                "Strategy: Credit card validated");
            return true;
        }

        public string ProcessPayment(
            decimal amount,
            string paymentDetails)
        {
            if (!ValidatePayment(paymentDetails))
            {
                throw new InvalidOperationException(
                    "Invalid credit card details");
            }

            string transactionId =
                $"CC-{DateTime.Now:yyyyMMddHHmmss}-" +
                $"{new Random().Next(10000, 99999)}";

            Logger.GetInstance().Log(
                $"Strategy: Processing credit card " +
                $"payment: ${amount}");

            Thread.Sleep(1000);
            // Simulate payment processing

            return transactionId;
        }

        public string GetPaymentMethodName()
        {
            return "Credit Card";
        }

        public decimal GetTransactionFee(
            decimal amount)
        {
            // 2.5% transaction fee for credit card
            return amount * 0.025m;
        }
    }
}
