namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.BaseDecoratorClass.ConcreteDecoratorClass
{
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza pizza;

        public PizzaDecorator(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public virtual string GetDescription() => pizza.GetDescription();

        public virtual double GetCost() => pizza.GetCost();
    }
}
