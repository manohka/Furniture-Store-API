using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteComponent
{
    // Concrete Component: Base Coffee
    public class SimpleCoffee : IBeverage
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public decimal GetCost()
        {
            return 2.00m;
        }
    }
}
