using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.ConcreteStrategies
{
    // Concrete Strategy 3: Bank Transfer Payment
    public class BankTransferPayment : IPaymentStrategy
    {
        public bool ValidatePayment(
            string paymentDetails)
        {
            // Validate bank account format
            // Format: BANKCODE-ACCOUNTNUMBER
            if (string.IsNullOrEmpty(paymentDetails))
                return false;

            var parts = paymentDetails.Split('-');
            if (parts.Length != 2)
                return false;

            bool isValid = parts[0].Length == 4 &&
                          parts[1].Length >= 8;

            if (isValid)
            {
                Logger.GetInstance().Log(
                    "Strategy: Bank account validated");
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
                    "Invalid bank account details");
            }

            string transactionId =
                $"BT-{DateTime.Now:yyyyMMddHHmmss}-" +
                $"{new Random().Next(10000, 99999)}";

            Logger.GetInstance().Log(
                $"Strategy: Processing bank transfer " +
                $"payment: ${amount}");

            System.Threading.Thread.Sleep(2000);
            // Simulate bank transfer (slowest)

            return transactionId;
        }

        public string GetPaymentMethodName()
        {
            return "Bank Transfer";
        }

        public decimal GetTransactionFee(
            decimal amount)
        {
            // Fixed fee for bank transfer
            return 1.50m;
        }
    }
}
