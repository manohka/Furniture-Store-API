namespace FurnitureStoreAPI.Models
{
    // Facade
    /*public class OrderModels
    {

    }*/

    public class OrderRequest
    {
        public int FurnitureId { get; set; }
        public int Quantity { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
    }

    public class OrderResponse
    {
        public string OrderId { get; set; }
        public int FurnitureId { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalAmount { get; set; }
        public string TransactionId { get; set; }
        public string TrackingNumber { get; set; }
        public string WarrantyId { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
