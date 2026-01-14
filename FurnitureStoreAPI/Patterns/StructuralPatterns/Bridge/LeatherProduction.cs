namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Implementation 3: Leather
    public class LeatherProduction : IMaterialProduction
    {
        public string GetMaterialName()
        {
            return "Premium Leather Upholstery";
        }

        public string GetProductionMethod()
        {
            return "Tanning, cutting, and hand-stitching " +
                   "using premium Italian leather";
        }

        public decimal GetMaterialCost()
        {
            return 300m;
        }

        public string GetDurability()
        {
            return "Very High - Lasts 15+ years with care";
        }

        public string GetMaintenanceInfo()
        {
            return "Clean with leather soap and conditioner " +
                   "every 6 months. Protect from direct sunlight. " +
                   "Professional cleaning recommended annually.";
        }
    }
}
