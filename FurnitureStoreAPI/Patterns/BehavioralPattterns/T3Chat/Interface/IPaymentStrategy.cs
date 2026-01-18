namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.T3Chat.Interface
{
    // Strategy Interface: Defines algorithm contract
    public interface IPaymentStrategy
    {
        bool ValidatePayment(string paymentDetails);
        string ProcessPayment(
            decimal amount,
            string paymentDetails);
        string GetPaymentMethodName();
        decimal GetTransactionFee(decimal amount);
    }
}
