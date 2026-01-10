using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.AbstractFactory
{
    public class VictorianFurnitureFactory : IStyleFurnitureFactory
    {
        public Furniture CreateChair()
        {
            return new Furniture
            {
                Name = "Victorian Chair",
                Style = "Victorian",
                Price = 450,
                Material = "Wood",
                Color = "Gold"
            };
        }

        public Furniture CreateTable()
        {
            return new Furniture
            {
                Name = "Victorian Table",
                Style = "Victorian",
                Price = 700,
                Material = "Wood",
                Color = "Brown"
            };
        }

        public Furniture CreateSofa()
        {
            return new Furniture
            {
                Name = "Victorian Sofa",
                Style = "Victorian",
                Price = 1500,
                Material = "Velvet",
                Color = "Burgundy"
            };
        }
    }
}
