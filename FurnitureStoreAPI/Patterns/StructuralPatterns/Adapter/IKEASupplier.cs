using FurnitureStoreAPI.Models;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter
{
    // IKEA's own implementation with different interface
    public class IKEASupplier
    {
        public List<IKEAProdut> GetAvailableFurniture()
        {
            return new List<IKEAProdut>
            {
                new IKEAProdut
                {
                    ProductId = "IKEA001",
                    ProductName = "BILLY Bookcase",
                    ProductPrice = 59.99,
                    ProductMaterial = "Particleboard",
                    ProductColor = "White"
                },
                new IKEAProdut
                {
                    ProductId = "IKEA002",
                    ProductName = "MALM Bed Frame",
                    ProductPrice = 199.99,
                    ProductMaterial = "Wood",
                    ProductColor = "Black"
                }
            };
        }

        public IKEAProdut GetProductById(string productId)
        {
            var products = GetAvailableFurniture();
            return products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
