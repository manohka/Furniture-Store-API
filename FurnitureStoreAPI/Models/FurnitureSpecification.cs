namespace FurnitureStoreAPI.Models
{
    public class FurnitureSpecification
    {
        public string FurnitureType { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string ProductionMethod { get; set; }
        public decimal BasePrice { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal TotalPrice { get; set; }
        public string Durability { get; set; }
        public string MaintenanceInfo { get; set; }
    }
}
