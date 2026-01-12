using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter
{
    // Adapter to convert Wayfair's interface to IFurnitureSupplier
    public class WayfairAdapter : IFurnitureSupplier
    {
        private readonly WayfairSupplier _wayfairSupplier;

        public WayfairAdapter()
        {
            _wayfairSupplier = new WayfairSupplier();
        }

        public List<Furniture> GetFurnitureList()
        {
            var wayfairItems = _wayfairSupplier.RetrieveCatalog();
            return wayfairItems.Select(i => new Furniture
            {
                Id = int.Parse(i.SKU.Replace("WAY-", "")),
                Name = i.Description,
                Style = "Wayfair",
                Price = i.RetailPrice,
                Material = string.Join(", ", i.Materials),
                Color = i.AvailableColor
            }).ToList();
        }

        public Furniture GetFurnitureById(string id)
        {
            var sku = $"WAY-{id}";
            var item = _wayfairSupplier.GetItemBySKU(sku);
            if (item == null)
                return null;

            return new Furniture
            {
                Id = int.Parse(id),
                Name = item.Description,
                Style = "Wayfair",
                Price = item.RetailPrice,
                Material = string.Join(", ", item.Materials),
                Color = item.AvailableColor
            };
        }
    }
}
