using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.Builder
{
    public class FurnitureBuilder
    {
        private Furniture _furniture = new Furniture();

        public FurnitureBuilder SetName(string name)
        {
            _furniture.Name = name;
            return this;
        }

        public FurnitureBuilder SetStyle(string style)
        {
            _furniture.Style = style;
            return this;
        }

        public FurnitureBuilder SetPrice(decimal price)
        {
            _furniture.Price = price;
            return this;
        }

        public FurnitureBuilder SetMaterial(string material)
        {
            _furniture.Material = material;
            return this;
        }

        public FurnitureBuilder SetColor(string color)
        {
            _furniture.Color = color;
            return this;
        }

        public Furniture Build()
        {
            return _furniture;
        }
    }
}
