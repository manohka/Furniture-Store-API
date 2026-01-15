using FurnitureStoreAPI.Models.DecoratorCoffee;
using FurnitureStoreAPI.Services.DecoratorCoffeeService;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeShopService _coffeeShopService;

        public CoffeeController(CoffeeShopService coffeeShopService)
        {
            _coffeeShopService = coffeeShopService;
        }

        [HttpGet("menu")]
        public IActionResult GetMenu()
        {
            var menu = _coffeeShopService.GetMenu();

            return Ok(new
            {
                message = "Coffee Shop Menu",
                basePrice = 2.00m,
                menu = menu.Items
            });
        }

        [HttpGet("simple")]
        public IActionResult GetSimpleCoffee()
        {
            var coffee = _coffeeShopService.GetSimpleCoffee();

            return Ok(new
            {
                description = coffee.Description,
                cost = coffee.Cost,
                message = "Simple coffee without toppings"
            });
        }

        [HttpPost("build")]
        public IActionResult BuildBeverage([FromBody] CreateOrderRequest request)
        {
            try
            {
                var beverage = _coffeeShopService.BuildBeverage(request.Toppings);

                return Ok(new
                {
                    description = beverage.Description,
                    cost = beverage.Cost,
                    toppingsCount = request.Toppings.Count,
                    message = "Beverage configuration created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpPost("preview")]
        public IActionResult PreviewOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var preview = _coffeeShopService
                    .PreviewOrder(request);

                return Ok(new
                {
                    customerName =
                        request.CustomerName,
                    description = preview.Description,
                    cost = preview.Cost,
                    toppings = request.Toppings,
                    message = "Order preview " +
                        "(not placed yet)"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpPost("order")]
        public IActionResult PlaceOrder(
            [FromBody] CreateOrderRequest request)
        {
            try
            {
                var order = _coffeeShopService
                    .CreateOrder(request);

                return CreatedAtAction(
                    nameof(GetOrderById),
                    new { orderId = order.OrderId },
                    order);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet("order/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            try
            {
                var order = _coffeeShopService
                    .GetOrderById(orderId);
                return Ok(order);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet("orders")]
        public IActionResult GetAllOrders()
        {
            var allOrders = _coffeeShopService
                .GetAllOrders();

            return Ok(new
            {
                totalOrders = allOrders.TotalOrders,
                totalRevenue = allOrders.TotalRevenue,
                orders = allOrders.Orders
            });
        }

        [HttpPost("calculate-price")]
        public IActionResult CalculatePrice(
            [FromBody] CreateOrderRequest request)
        {
            try
            {
                var price = _coffeeShopService
                    .CalculatePrice(request.Toppings);

                return Ok(new
                {
                    basePrice = 2.00m,
                    toppings = request.Toppings,
                    additionalCost = price - 2.00m,
                    totalPrice = price,
                    message = "Price calculated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var allOrders = _coffeeShopService
                .GetAllOrders();

            return Ok(new
            {
                totalOrders = allOrders.TotalOrders,
                totalRevenue = allOrders.TotalRevenue,
                averageOrderPrice =
                    allOrders.TotalOrders > 0
                        ? allOrders.TotalRevenue /
                          allOrders.TotalOrders
                        : 0,
                message = "Coffee Shop Statistics"
            });
        }
    }
}
