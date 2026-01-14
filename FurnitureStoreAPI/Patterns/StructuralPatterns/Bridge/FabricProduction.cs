namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Implementation 4: Fabric
    public class FabricProduction : IMaterialProduction
    {
        public string GetMaterialName()
        {
            return "Premium Upholstery Fabric";
        }

        public string GetProductionMethod()
        {
            return "Factory-woven European fabric " +
                   "with staple gun upholstering";
        }

        public decimal GetMaterialCost()
        {
            return 120m;
        }

        public string GetDurability()
        {
            return "Medium - Lasts 7-10 years";
        }

        public string GetMaintenanceInfo()
        {
            return "Vacuum regularly. Spot clean with " +
                   "upholstery cleaner. Professional cleaning " +
                   "every 12-18 months recommended.";
        }
    }
}
