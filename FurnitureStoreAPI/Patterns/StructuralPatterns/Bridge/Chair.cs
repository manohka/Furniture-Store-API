namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Abstraction 1: Chair
    public class Chair : BridgeFurniture
    {
        public Chair(IMaterialProduction materialProduction) : base(materialProduction)
        {
            FurnitureType = "Chair";
            BasePrice = 200m;
        }

        public override string GetFurnitureType()
        {
            return "Dining Chair";
        }

        public override string GetDescription()
        {
            return $"Premium {GetFurnitureType()} made with " +
                   $"{_materialProduction.GetMaterialName()}. " +
                   $"Perfect for dining rooms or offices.";
        }
    }
}
