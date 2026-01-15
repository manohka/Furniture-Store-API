using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.DecoratorBaseClass;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteDecorators
{
    // Concrete Decorator 1: Milk
    public class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(IBeverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Milk";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.50m;
        }
    }
}
