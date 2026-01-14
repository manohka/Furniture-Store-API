namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Concrete Abstraction 2: Table
    public class Table : BridgeFurniture
    {
        public Table( IMaterialProduction materialProduction ) : base( materialProduction )
        {
            FurnitureType = "Table";
            BasePrice = 400m; // Base price for any table
        }

        public override string GetFurnitureType()
        {
            return "Dining Table";
        }

        public override string GetDescription()
        {
            return $"Elegant {GetFurnitureType()} crafted with " +
                   $"{_materialProduction.GetMaterialName()}. " +
                   $"Spacious and stylish for modern homes.";
        }
    }
}
