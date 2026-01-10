using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.AbstractFactory
{
    public class ModernFurnitureFactory : IStyleFurnitureFactory
    {
        public Furniture CreateChair()
        {
            return new Furniture
            {
                Name = "Modern Chair",
                Style = "Modern",
                Price = 250,
                Material = "Metal & Leather",
                Color = "Black"
            };
        }

        public Furniture CreateTable()
        {
            return new Furniture
            {
                Name = "Modern Table",
                Style = "Modern",
                Price = 500,
                Material = "Glass & Steel",
                Color = "White"
            };
        }

        public Furniture CreateSofa()
        {
            return new Furniture
            {
                Name = "Modern Sofa",
                Style = "Modern",
                Price = 1200,
                Material = "Fabric",
                Color = "Gray"
            };
        }
    }
}
