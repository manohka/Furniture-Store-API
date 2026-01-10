using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.FactoryMethod
{
    public class TableFactory : IFurnitureFactory
    {
        public Furniture CreateFurniture()
        {
            return new Furniture
            {
                Name = "Dining Table",
                Style = "Contemporary",
                Price = 400,
                Material = "Wood",
                Color = "Black"
            };
        }
    }
}
