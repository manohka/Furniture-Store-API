using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.FactoryMethod
{
    public class SofaFactory : IFurnitureFactory
    {
        public Furniture CreateFurniture()
        {
            return new Furniture
            {
                Name = "Comfortable Sofa",
                Style = "Modern",
                Price = 800,
                Material = "Fabric",
                Color = "Gray"
            };
        }
    }
}
