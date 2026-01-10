using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.FactoryMethod
{
    public class ChairFactory : IFurnitureFactory
    {
        public Furniture CreateFurniture()
        {
            return new Furniture
            {
                Name = "Standard Chair",
                Style = "Classic",
                Price = 150,
                Material = "Wood",
                Color = "Brown"
            };
        }
    }
}
