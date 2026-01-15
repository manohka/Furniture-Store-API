namespace FurnitureStoreAPI.Models
{
    /*public class CompositeModels
    {
    }*/

    public class CompositeItemResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public decimal TotalPrice { get; set; }
        public string Type { get; set; } // "Item" or "Collection"
        public List<CompositeItemResponse> Children
        { get; set; } = new();
    }

    public class CatalogSummary
    {
        public string Name { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalPrice { get; set; }
        public double TotalWeight { get; set; }
        public List<CollectionSummary> Collections
        { get; set; } = new();
    }

    public class CollectionSummary
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
