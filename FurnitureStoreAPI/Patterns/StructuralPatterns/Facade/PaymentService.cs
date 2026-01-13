namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Facade
{
    // Subsystem 2: Payment Processing
    public class PaymentService
    {
        public bool ProcessPayment(
            string cardNumber,
            decimal amount,
            string cardholderName)
        {
            // Simulate payment validation
            if (string.IsNullOrEmpty(cardNumber) ||
                cardNumber.Length < 4)
            {
                throw new InvalidOperationException(
                    "Invalid card number");
            }

            if (amount <= 0)
            {
                throw new InvalidOperationException(
                    "Invalid amount");
            }

            Console.WriteLine(
                $"✓ Payment processed: ${amount:F2} " +
                $"from {cardholderName}");
            return true;
        }

        public string GenerateTransactionId()
        {
            return $"TXN-{DateTime.Now:yyyyMMddHHmmss}" +
                   $"-{new Random().Next(1000, 9999)}";
        }
    }
}
