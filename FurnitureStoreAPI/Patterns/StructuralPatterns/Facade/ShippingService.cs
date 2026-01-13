namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Facade
{
    // Subsystem 3: Shipping Management
    public class ShippingService
    {
        public decimal CalculateShippingCost(
            decimal itemPrice,
            int quantity,
            string shippingAddress)
        {
            if (string.IsNullOrEmpty(shippingAddress))
            {
                throw new InvalidOperationException(
                    "Shipping address required");
            }

            // Simple calculation: $10 base + $2 per item
            decimal shippingCost = 10 + (quantity * 2);

            Console.WriteLine(
                $"✓ Shipping calculated: ${shippingCost:F2} " +
                $"to {shippingAddress}");
            return shippingCost;
        }

        public string GenerateTrackingNumber()
        {
            return $"TRACK-{new Random().Next(100000, 999999)}";
        }
    }
}
