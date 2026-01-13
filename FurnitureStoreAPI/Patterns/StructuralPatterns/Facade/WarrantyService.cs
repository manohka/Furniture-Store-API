namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Facade
{
    // Subsystem 4: Warranty Management
    public class WarrantyService
    {
        public string SetupWarranty(
            int furnitureId,
            decimal itemPrice)
        {
            // Standard warranty: 1 year for items over $100
            int warrantyMonths = itemPrice > 100 ? 12 : 6;

            string warrantyId =
                $"WARRANTY-{furnitureId}-" +
                $"{DateTime.Now:yyyyMMdd}";

            Console.WriteLine(
                $"✓ Warranty activated: {warrantyId} " +
                $"({warrantyMonths} months)");
            return warrantyId;
        }
    }
}
