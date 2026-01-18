using FurnitureStoreAPI.Models.T3ChatStrategy;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.ConcreteStrategies;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Interface;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Services.StrategyPaymentService
{
    // CONTEXT STRATEGY CLASS
    public class StrategyPaymentService
    {
        private List<PaymentResponse> _transactions = new();

        // // Get strategy based on payment method
        private IPaymentStrategy GetPaymentStrategy(string paymentMethod)
        {
            return paymentMethod.ToLower() switch
            {
                "creditcard" =>
                    new CreditCardPayment(),
                "paypal" =>
                    new PayPalPayment(),
                "banktransfer" =>
                    new BankTransferPayment(),
                "cryptocurrency" =>
                    new CryptocurrencyPayment(),
                _ => throw new ArgumentException(
                    $"Unknown payment method: " +
                    $"{paymentMethod}")
            };
        }

        public PaymentResponse ProcessPayment(
            ProcessPaymentRequest request)
        {
            if (request.Amount <= 0)
            {
                throw new ArgumentException(
                    "Amount must be greater than 0");
            }

            // Get the strategy
            var strategy = GetPaymentStrategy(
                request.PaymentMethod);

            Logger.GetInstance().Log(
                $"Service: Using strategy " +
                $"{strategy.GetPaymentMethodName()}");

            // Process payment using strategy
            string transactionId = strategy
                .ProcessPayment(
                    request.Amount,
                    request.PaymentDetails);

            decimal fee = strategy
                .GetTransactionFee(request.Amount);
            decimal totalAmount =
                request.Amount + fee;

            var response = new PaymentResponse
            {
                TransactionId = transactionId,
                Amount = request.Amount,
                TransactionFee = fee,
                TotalAmount = totalAmount,
                PaymentMethod =
                    strategy.GetPaymentMethodName(),
                Status = "Success",
                ProcessedAt = DateTime.Now,
                Message = "Payment processed successfully"
            };

            _transactions.Add(response);

            Logger.GetInstance().Log(
                $"Service: Payment processed - " +
                $"ID: {transactionId}");

            return response;
        }

        public ValidatePaymentResponse ValidatePayment(
            string paymentMethod,
            string paymentDetails)
        {
            try
            {
                var strategy = GetPaymentStrategy(
                    paymentMethod);

                bool isValid = strategy
                    .ValidatePayment(paymentDetails);

                return new ValidatePaymentResponse
                {
                    IsValid = isValid,
                    PaymentMethod =
                        strategy
                        .GetPaymentMethodName(),
                    Message = isValid
                        ? "Payment details are valid"
                        : "Payment details are invalid"
                };
            }
            catch (Exception ex)
            {
                return new ValidatePaymentResponse
                {
                    IsValid = false,
                    PaymentMethod = paymentMethod,
                    Message = ex.Message
                };
            }
        }

        public List<PaymentMethodInfo>
            GetAvailablePaymentMethods()
        {
            return new List<PaymentMethodInfo>
            {
                new PaymentMethodInfo
                {
                    Name = "Credit Card",
                    Description =
                        "Pay using credit/debit card",
                    Format =
                        "XXXX-XXXX-XXXX-XXXX",
                    FeePercentage = 2.5m
                },
                new PaymentMethodInfo
                {
                    Name = "PayPal",
                    Description =
                        "Pay using PayPal account",
                    Format = "email@example.com",
                    FeePercentage = 3.5m
                },
                new PaymentMethodInfo
                {
                    Name = "Bank Transfer",
                    Description =
                        "Pay via bank transfer",
                    Format = "BANKCODE-ACCOUNTNUMBER",
                    FeePercentage = 0m
                },
                new PaymentMethodInfo
                {
                    Name = "Cryptocurrency",
                    Description =
                        "Pay using cryptocurrency",
                    Format = "0x" +
                        new string('x', 40),
                    FeePercentage = 1.0m
                }
            };
        }

        public List<PaymentResponse>
            GetAllTransactions()
        {
            return new List<PaymentResponse>(
                _transactions);
        }

        public PaymentResponse GetTransaction(
            string transactionId)
        {
            var transaction = _transactions
                .FirstOrDefault(t => 
                    t.TransactionId == transactionId);

            if (transaction == null)
            {
                throw new KeyNotFoundException(
                    $"Transaction {transactionId} " +
                    $"not found");
            }

            return transaction;
        }
    }
}
