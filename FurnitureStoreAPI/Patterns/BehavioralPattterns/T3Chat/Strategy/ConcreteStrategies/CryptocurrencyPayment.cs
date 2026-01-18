using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Strategy.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Strategy.ConcreteStrategies
{
    // Concrete Strategy 4: Cryptocurrency Payment
    public class CryptocurrencyPayment : IPaymentStrategy
    {
        public bool ValidatePayment(
            string paymentDetails)
        {
            // Validate wallet address
            // Format: 0x followed by 40 hex characters
            if (string.IsNullOrEmpty(paymentDetails))
                return false;

            bool isValid =
                paymentDetails.StartsWith("0x") &&
                paymentDetails.Length == 42;

            if (isValid)
            {
                Logger.GetInstance().Log(
                    "Strategy: Crypto wallet " +
                    "validated");
            }

            return isValid;
        }

        public string ProcessPayment(
            decimal amount,
            string paymentDetails)
        {
            if (!ValidatePayment(paymentDetails))
            {
                throw new InvalidOperationException(
                    "Invalid cryptocurrency wallet");
            }

            string transactionId =
                $"CRYPTO-" +
                $"{DateTime.Now:yyyyMMddHHmmss}-" +
                $"{new Random().Next(10000, 99999)}";

            Logger.GetInstance().Log(
                $"Strategy: Processing crypto payment " +
                $"to {paymentDetails}: ${amount}");

            Thread.Sleep(3000);
            // Simulate blockchain transaction

            return transactionId;
        }

        public string GetPaymentMethodName()
        {
            return "Cryptocurrency";
        }

        public decimal GetTransactionFee(
            decimal amount)
        {
            // 1% fee for cryptocurrency
            return amount * 0.01m;
        }
    }
}
