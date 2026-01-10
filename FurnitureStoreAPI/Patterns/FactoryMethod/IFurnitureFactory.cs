using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.FactoryMethod
{
    public interface IFurnitureFactory
    {
        Furniture CreateFurniture();
    }
}
