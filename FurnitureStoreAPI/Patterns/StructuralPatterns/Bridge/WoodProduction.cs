namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Implementation 1: Wood
    public class WoodProduction : IMaterialProduction
    {
        public string GetMaterialName()
        {
            return "Solid Wood";
        }

        public string GetProductionMethod()
        {
            return "Hand-crafted woodworking with " +
                   "traditional joinery techniques";
        }

        public decimal GetMaterialCost()
        {
            return 150m;
        }

        public string GetDurability()
        {
            return "Very High - Lasts 15+ years";
        }

        public string GetMaintenanceInfo()
        {
            return "Requires regular oiling and polishing. " +
                   "Protect from moisture and direct sunlight.";
        }
    }
}
