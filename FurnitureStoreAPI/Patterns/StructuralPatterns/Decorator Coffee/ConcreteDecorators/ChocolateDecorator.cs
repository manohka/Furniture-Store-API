using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.DecoratorBaseClass;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteDecorators
{
    // Concrete Decorator 4: Chocolate
    public class ChocolateDecorator : BeverageDecorator
    {
        public ChocolateDecorator(IBeverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() +
                   ", Chocolate";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.75m;
        }
    }
}
