using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.AbstractFactory
{
    public interface IStyleFurnitureFactory
    {
        Furniture CreateChair();
        Furniture CreateTable();
        Furniture CreateSofa();

    }
}
