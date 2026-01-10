using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Services
{
    public class FurnitureService
    {
        private List<Furniture> _furnitureInventory = new List<Furniture>();
        private int _nextId = 1;
        public FurnitureService() { }
    }
}
