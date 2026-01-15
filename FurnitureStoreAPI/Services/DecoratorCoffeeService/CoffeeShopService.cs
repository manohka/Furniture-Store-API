using FurnitureStoreAPI.Models.DecoratorCoffee;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteComponent;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteDecorators;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Services.DecoratorCoffeeService
{
    public class CoffeeShopService
    {
        private int _orderCounter = 1;
        private List<CoffeeOrder> _orders = new();

        public MenuResponse GetMenu()
        {
            var menu = new MenuResponse
            {
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Name = "Simple Coffee",
                        Price = 2.00m,
                        Type = "Base"
                    },
                    new MenuItem
                    {
                        Name = "Milk",
                        Price = 0.50m,
                        Type = "Topping"
                    },
                    new MenuItem
                    {
                        Name = "Sugar",
                        Price = 0.25m,
                        Type = "Topping"
                    },
                    new MenuItem
                    {
                        Name = "Caramel",
                        Price = 0.75m,
                        Type = "Topping"
                    },
                    new MenuItem
                    {
                        Name = "Chocolate",
                        Price = 0.75m,
                        Type = "Topping"
                    },
                    new MenuItem
                    {
                        Name = "Whipped Cream",
                        Price = 0.50m,
                        Type = "Topping"
                    },
                    new MenuItem
                    {
                        Name = "Vanilla",
                        Price = 0.60m,
                        Type = "Topping"
                    },
                    new MenuItem
                    {
                        Name = "Honey",
                        Price = 0.40m,
                        Type = "Topping"
                    }
                }
            };

            return menu;
        }

        public BeverageResponse GetSimpleCoffee()
        {
            IBeverage coffee = new SimpleCoffee();

            return new BeverageResponse
            {
                Description = coffee.GetDescription(),
                Cost = coffee.GetCost(),
            };
        }

        public BeverageResponse BuildBeverage(List<string> toppings)
        {
            IBeverage beverage = new SimpleCoffee();

            foreach (var topping in toppings)
            {
                beverage = topping.ToLower() switch
                {
                    "milk" => new MilkDecorator(beverage),
                    "sugar" => new SugarDecorator(beverage),
                    "caramel" =>
                        new CaramelDecorator(beverage),
                    "chocolate" =>
                        new ChocolateDecorator(beverage),
                    "whipped cream" =>
                        new WhippedCreamDecorator(
                            beverage),
                    "vanilla" =>
                        new VanillaDecorator(beverage),
                    "honey" =>
                        new HoneyDecorator(beverage),
                    _ => beverage
                };
            }

            return new BeverageResponse
            {
                Description = beverage.GetDescription(),
                Cost = beverage.GetCost(),
            };
        }

        public OrderResponse CreateOrder(
            CreateOrderRequest request)
        {
            if (string.IsNullOrEmpty(request.CustomerName))
            {
                throw new ArgumentNullException("Customer name is required");
            }

            var beverage = BuildBeverage(request.Toppings);

            var order = new CoffeeOrder(
                _orderCounter++,
                beverage.Description,
                beverage.Cost,
                request.CustomerName);

            _orders.Add(order);

            return new OrderResponse
            {
                OrderId = order.OrderId,
                BeverageName = order.BeverageName,
                Cost = order.Cost,
                OrderTime = order.OrderTime,
                CustomerName = order.CustomerName,
                Message = "Order placed successfully."
            };
        }

        public AllOrdersResponse GetAllOrders()
        {
            var orderResponses = _orders.Select(o =>
                new OrderResponse
                {
                    OrderId = o.OrderId,
                    BeverageName = o.BeverageName,
                    Cost = o.Cost,
                    OrderTime = o.OrderTime,
                    CustomerName = o.CustomerName
                }
                ).ToList();

            return new AllOrdersResponse
            {
                Orders = orderResponses,
                TotalRevenue = _orders.Sum(o => o.Cost),
                TotalOrders = _orders.Count
            };
        }

        public OrderResponse GetOrderById(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                throw new KeyNotFoundException(
                    $"Order {orderId} not found");
            }

            return new OrderResponse
            {
                OrderId = order.OrderId,
                BeverageName = order.BeverageName,
                Cost = order.Cost,
                OrderTime = order.OrderTime,
                CustomerName = order.CustomerName
            };
        }

        public BeverageResponse PreviewOrder(CreateOrderRequest request)
        {
            if (string.IsNullOrEmpty(request.CustomerName))
            {
                throw new ArgumentException(
                    "Customer name is required");
            }

            return BuildBeverage(request.Toppings);
        }

        public decimal CalculatePrice(List<string> toppings)
        {
            var beverage = BuildBeverage(toppings);
            return beverage.Cost;
        }
    }
}
