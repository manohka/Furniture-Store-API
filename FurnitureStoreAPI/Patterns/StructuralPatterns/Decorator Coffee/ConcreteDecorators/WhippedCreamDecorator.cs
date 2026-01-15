using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.DecoratorBaseClass;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteDecorators
{
    // Concrete Decorator 5: Whipped Cream
    public class WhippedCreamDecorator
        : BeverageDecorator
    {
        public WhippedCreamDecorator(IBeverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() +
                   ", Whipped Cream";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.50m;
        }
    }
}
