using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter
{
    // Adapter to convert Ashley Furniture's interface to IFurnitureSupplier
    public class AshleyFurnitureAdapter : IFurnitureSupplier
    {
        private readonly AshleyFurnitureSupplier _ashleySupplier;

        public AshleyFurnitureAdapter()
        {
            _ashleySupplier = new AshleyFurnitureSupplier();
        }

        public List<Furniture> GetFurnitureList()
        {
            var ashleyItems = _ashleySupplier.FetchFurnitureProducts();
            return ashleyItems.Select(i => new Furniture
            {
                Id = i.ItemCode,
                Name = i.ItemTitle,
                Style = "Ashley Furniture",
                Price = i.Cost,
                Material = i.Composition,
                Color = i.Shade
            }).ToList();
        }

        public Furniture GetFurnitureById(string id)
        {
            if (!int.TryParse(id, out int itemCode))
                return null;

            var item = _ashleySupplier.FetchItemById(itemCode);
            if (item == null)
                return null;

            return new Furniture
            {
                Id = item.ItemCode,
                Name = item.ItemTitle,
                Style = "Ashley Furniture",
                Price = item.Cost,
                Material = item.Composition,
                Color = item.Shade
            };
        }
    }
}
