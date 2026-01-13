namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Facade
{
    // Subsystem 5: Notification System
    public class NotificationService
    {
        public void SendOrderConfirmation(
            string customerEmail,
            string orderId,
            decimal totalAmount)
        {
            Console.WriteLine(
                $"✓ Email sent to {customerEmail}: " +
                $"Order {orderId} confirmed (${totalAmount:F2})");
        }

        public void SendShippingNotification(
            string customerEmail,
            string trackingNumber)
        {
            Console.WriteLine(
                $"✓ Email sent to {customerEmail}: " +
                $"Your order shipped (Tracking: {trackingNumber})");
        }
    }
}
