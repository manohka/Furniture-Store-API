using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter
{
    // Common interface that all suppliers must follow
    public interface IFurnitureSupplier
    {
        List<Furniture> GetFurnitureList();
        Furniture GetFurnitureById(string id);
    }
}
