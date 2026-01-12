using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter
{
    // Ashley Furniture's own implementation with different interface
    public class AshleyFurnitureSupplier
    {
        public List<AshleyFurnitureItem> FetchFurnitureProducts()
        {
            return new List<AshleyFurnitureItem>
            {
                new AshleyFurnitureItem
                {
                    ItemCode = 5001,
                    ItemTitle = "Contemporary Sectional Sofa",
                    Cost = 899.99m,
                    Composition = "Fabric Blend",
                    Shade = "Gray"
                },
                new AshleyFurnitureItem
                {
                    ItemCode = 5002,
                    ItemTitle = "Leather Recliner Chair",
                    Cost = 549.99m,
                    Composition = "Leather",
                    Shade = "Brown"
                }
            };
        }

        public AshleyFurnitureItem FetchItemById(int itemCode)
        {
            var items = FetchFurnitureProducts();
            return items.FirstOrDefault(i => i.ItemCode == itemCode);
        }
    }
}
