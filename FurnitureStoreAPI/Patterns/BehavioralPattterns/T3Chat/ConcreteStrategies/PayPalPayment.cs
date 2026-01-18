using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.ConcreteStrategies
{
    // Concrete Strategy 2: PayPal Payment
    public class PayPalPayment : IPaymentStrategy
    {
        public bool ValidatePayment(
            string paymentDetails)
        {
            // Validate PayPal email format
            if (string.IsNullOrEmpty(paymentDetails))
                return false;

            bool isValidEmail =
                paymentDetails.Contains("@") &&
                paymentDetails.Contains(".");

            if (isValidEmail)
            {
                Logger.GetInstance().Log(
                    "Strategy: PayPal email validated");
            }

            return isValidEmail;
        }

        public string ProcessPayment(
            decimal amount,
            string paymentDetails)
        {
            if (!ValidatePayment(paymentDetails))
            {
                throw new InvalidOperationException(
                    "Invalid PayPal email");
            }

            string transactionId =
                $"PP-{DateTime.Now:yyyyMMddHHmmss}-" +
                $"{new Random().Next(10000, 99999)}";

            Logger.GetInstance().Log(
                $"Strategy: Processing PayPal payment " +
                $"for {paymentDetails}: ${amount}");

            System.Threading.Thread.Sleep(1500);
            // Simulate API call to PayPal

            return transactionId;
        }

        public string GetPaymentMethodName()
        {
            return "PayPal";
        }

        public decimal GetTransactionFee(
            decimal amount)
        {
            // 3.5% transaction fee for PayPal
            return amount * 0.035m;
        }
    }
}
