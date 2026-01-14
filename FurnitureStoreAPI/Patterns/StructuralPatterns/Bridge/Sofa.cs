namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Abstraction 3: Sofa
    public class Sofa : BridgeFurniture
    {
        public Sofa(IMaterialProduction materialProduction)
            : base(materialProduction)
        {
            FurnitureType = "Sofa";
            BasePrice = 800m; // Base price for any sofa
        }

        public override string GetFurnitureType()
        {
            return "Living Room Sofa";
        }

        public override string GetDescription()
        {
            return $"Luxurious {GetFurnitureType()} upholstered " +
                   $"in {_materialProduction.GetMaterialName()}. " +
                   $"Ultimate comfort for your living space.";
        }
    }
}
