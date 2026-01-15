using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.DecoratorBaseClass;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteDecorators
{
    // Concrete Decorator 6: Vanilla
    public class VanillaDecorator : BeverageDecorator
    {
        public VanillaDecorator(IBeverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() +
                   ", Vanilla";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.60m;
        }
    }
}
