namespace FurnitureStoreAPI.Models.DecoratorCoffee
{
    public class CoffeeOrder
    {
        public int OrderId { get; set; }
        public string BeverageName { get; set; }
        public decimal Cost { get; set; }
        public DateTime OrderTime { get; set; }
        public string CustomerName { get; set; }

        public CoffeeOrder(
            int orderId,
            string beverageName,
            decimal cost,
            string customerName)
        {
            OrderId = orderId;
            BeverageName = beverageName;
            Cost = cost;
            OrderTime = DateTime.Now;
            CustomerName = customerName;
        }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; } // "Base" or "Topping"
    }

    public class BeverageResponse
    {
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }

    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public List<string> Toppings { get; set; } =
            new();
    }

    public class OrderResponse
    {
        public int OrderId { get; set; }
        public string BeverageName { get; set; }
        public decimal Cost { get; set; }
        public DateTime OrderTime { get; set; }
        public string CustomerName { get; set; }
        public string Message { get; set; }
    }

    public class MenuResponse
    {
        public List<MenuItem> Items { get; set; }
    }

    public class AllOrdersResponse
    {
        public List<OrderResponse> Orders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
    }

}
