using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.DecoratorBaseClass;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteDecorators
{
    // Concrete Decorator 7: Honey
    public class HoneyDecorator : BeverageDecorator
    {
        public HoneyDecorator(IBeverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() +
                   ", Honey";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.40m;
        }
    }
}
