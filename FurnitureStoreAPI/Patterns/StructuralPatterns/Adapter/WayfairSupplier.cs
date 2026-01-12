using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter
{
    // Wayfair's own implementation with different interface
    public class WayfairSupplier
    {
        public List<WayfairCatalogItem> RetrieveCatalog()
        {
            return new List<WayfairCatalogItem>
            {
                new WayfairCatalogItem
                {
                    SKU = "WAY-2001",
                    Description = "Rustic Wooden Dining Table",
                    RetailPrice = 449.99m,
                    Materials = new List<string> { "Solid Oak", "Steel" },
                    AvailableColor = "Natural"
                },
                new WayfairCatalogItem
                {
                    SKU = "WAY-2002",
                    Description = "Ergonomic Office Desk Chair",
                    RetailPrice = 349.99m,
                    Materials = new List<string> { "Mesh", "Plastic" },
                    AvailableColor = "Blue"
                }
            };
        }

        public WayfairCatalogItem GetItemBySKU(string sku)
        {
            var items = RetrieveCatalog();
            return items.FirstOrDefault(i => i.SKU == sku);
        }
    }
}
