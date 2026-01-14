namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Abstraction 4: Bed
    public class Bed : BridgeFurniture
    {
        public Bed(IMaterialProduction materialProduction)
            : base(materialProduction)
        {
            FurnitureType = "Bed";
            BasePrice = 600m; // Base price for any bed
        }

        public override string GetFurnitureType()
        {
            return "Platform Bed";
        }

        public override string GetDescription()
        {
            return $"Comfortable {GetFurnitureType()} made with " +
                   $"{_materialProduction.GetMaterialName()}. " +
                   $"Perfect for a good night's sleep.";
        }
    }
}
