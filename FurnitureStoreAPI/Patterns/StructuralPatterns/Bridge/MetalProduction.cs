namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Implementation 2: Metal
    public class MetalProduction : IMaterialProduction
    {
        public string GetMaterialName()
        {
            return "Steel Frame";
        }

        public string GetProductionMethod()
        {
            return "Industrial welding and powder coating " +
                   "with precision machinery";
        }

        public decimal GetMaterialCost()
        {
            return 100m;
        }

        public string GetDurability()
        {
            return "High - Lasts 10-12 years";
        }

        public string GetMaintenanceInfo()
        {
            return "Wipe clean with dry cloth. " +
                   "Avoid moisture to prevent rust. " +
                   "Re-coat if scratches appear.";
        }
    }
}
