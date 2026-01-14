using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Abstraction Interface
    public interface IFurnitureType
    {
        string GetFurnitureType();
        string GetDescription();
        decimal CalculatePrice();
        FurnitureSpecification GetSpecification();
    }
}
