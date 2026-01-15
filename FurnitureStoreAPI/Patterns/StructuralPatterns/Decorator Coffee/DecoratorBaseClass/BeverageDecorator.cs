using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.Interface;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Coffee.DecoratorBaseClass
{
    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage _beverage;

        public BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public virtual string GetDescription()
        {
            return _beverage.GetDescription();
        }

        public virtual decimal GetCost()
        {
            return _beverage.GetCost();
        }
    }
}
