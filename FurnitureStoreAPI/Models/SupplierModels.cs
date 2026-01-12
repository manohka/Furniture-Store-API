namespace FurnitureStoreAPI.Models
{
    // IKEA's way of returning furniture
    public class IKEAProdut
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductMaterial { get; set; }
        public string ProductColor { get; set; }
    }

    // Ashley Furniture's way of returning furniture
    public class AshleyFurnitureItem
    {
        public int ItemCode { get; set; }
        public string ItemTitle { get; set; }
        public decimal Cost { get; set; }
        public string Composition { get; set; }
        public string Shade { get; set; }
    }

    // Wayfair's way of returning furniture
    public class WayfairCatalogItem
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public List<string> Materials { get; set; }
        public string AvailableColor { get; set; }
    }
}
