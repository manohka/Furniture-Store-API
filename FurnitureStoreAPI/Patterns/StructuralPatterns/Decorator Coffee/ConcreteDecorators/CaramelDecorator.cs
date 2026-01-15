using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.DecoratorBaseClass;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.ConcreteDecorators
{
    // Concrete Decorator 3: Caramel
    public class CaramelDecorator : BeverageDecorator
    {
        public CaramelDecorator(IBeverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Caramel";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.75m;
        }
    }
}
