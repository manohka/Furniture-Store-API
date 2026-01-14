using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Proxy
{
    // Subject Interface
    public interface IFurnitureAccess
    {
        Furniture GetFurniture(int furnitureId);
        List<Furniture> GetAllFurniture();
        decimal GetPrice(int furnitureId);
        void LogAccess(int userId, int furnitureId);
    }
}


// Notes on Key Proxy Features Implemented:

// Access Control - Regular users can't access premium items

// Caching - Expensive DB calls cached after first access

// Lazy Loading - Real object created only when needed

// Discount Application - Different discounts per membership

// Access Logging - Track who accessed what

// Performance - Notice how second calls are instant (cached)