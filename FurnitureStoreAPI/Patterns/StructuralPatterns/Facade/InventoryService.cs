namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Facade
{
    // Create complex subsystem classes

    // Subsystem 1: Inventory Management
    public class InventoryService
    {
        private Dictionary<int, int> _stock = new()
        {
            { 1, 5 },
            { 2, 3 },
            { 3, 10 }
        };

        public bool CheckAvailability(int furnitureId, int quantity)
        {
            if(_stock.ContainsKey(furnitureId))
            {
                return _stock[furnitureId] >= quantity;
            }
            return false;
        }

        public void ReserveItem(int furnitureId, int quantity)
        {
            if(CheckAvailability(furnitureId, quantity))
            {
                _stock[furnitureId] -= quantity;
                Console.WriteLine(
                    $"✓ Inventory reserved: {furnitureId} " +
                    $"(Qty: {quantity})");
            }
            else
            {
                throw new InvalidOperationException(
                    "Insufficient stock");
            }
        }

        public int GetStock(int furnitureId)
        {
            return _stock.ContainsKey(furnitureId)
                ? _stock[furnitureId]
                : 0;
        }
    }
}
