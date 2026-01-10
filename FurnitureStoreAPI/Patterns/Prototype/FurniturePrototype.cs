using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.Prototype
{
    public interface IFurniturePrototype
    {
        Furniture Clone();
    }
    public class FurniturePrototype : IFurniturePrototype
    {
        private Furniture _furniture;

        public FurniturePrototype(Furniture furniture)
        {
            _furniture = furniture;
        }

        public Furniture Clone()
        {
            return new Furniture
            {
                Id = _furniture.Id,
                Name = _furniture.Name,
                Style = _furniture.Style,
                Price = _furniture.Price,
                Material = _furniture.Material,
                Color = _furniture.Color
            };
        }
    }
}
