using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.ConcreteComponent;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.ToppingDecorators;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet("order")]
        public IActionResult GetPizzaOrder()
        {
            // Create a Margherita pizza
            IPizza pizza = new Margherita();

            var result = new
            {
                description = pizza.GetDescription(),
                cost = pizza.GetCost(),
            };

            // Add Olive Toppings
            pizza = new OliveDecorator(pizza);

            var withOlive = new
            {
                description = pizza.GetDescription(),
                cost = pizza.GetCost()
            };

            // Add Cheese Toppings
            pizza = new CheeseDecorator(pizza);

            var withCheese = new
            {
                description = pizza.GetDescription(),
                cost = pizza.GetCost()
            };

            return Ok(new
            {
                baseOrder = result,
                withOlive,
                withCheese
            });
        }
    }
}
