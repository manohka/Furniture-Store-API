using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter
{
    // Adapter to convert IKEA's interface to IFurnitureSupplier
    public class IKEAAdapter : IFurnitureSupplier
    {
        private readonly IKEASupplier _ikeaSupplier;

        public IKEAAdapter()
        {
            _ikeaSupplier = new IKEASupplier();
        }

        public List<Furniture> GetFurnitureList()
        {
            var ikeaProducts = _ikeaSupplier.GetAvailableFurniture();

            return ikeaProducts.Select(p => new Furniture
            {
                Id = int.Parse(p.ProductId.Replace("IKEA", "")),
                Name = p.ProductName,
                Style = "IKEA",
                Price = (decimal)p.ProductPrice,
                Material = p.ProductMaterial,
                Color = p.ProductColor
            }).ToList();
        }

        public Furniture GetFurnitureById(string id)
        {
            var product = _ikeaSupplier.GetProductById(id);

            if (product == null)
                return null;

            return new Furniture
            {
                Id = int.Parse(product.ProductId.Replace("IKEA", "")),
                Name = product.ProductName,
                Style = "IKEA",
                Price = (decimal)product.ProductPrice,
                Material = product.ProductMaterial,
                Color = product.ProductColor
            };
        }
    }
}
