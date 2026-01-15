using FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.BaseDecoratorClass.ConcreteDecoratorClass;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.ToppingDecorators
{
    public class OliveDecorator : PizzaDecorator
    {
        public OliveDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return pizza.GetDescription() + "Olives";
        }

        public override double GetCost()
        {
            return pizza.GetCost() + 20;
        }
    }

    public class TomatoDecorator : PizzaDecorator
    {
        public TomatoDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription() =>
            pizza.GetDescription() + ", Tomato";

        public override double GetCost() => pizza.GetCost() + 30;
    }

    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription() =>
            pizza.GetDescription() + ", Cheese";

        public override double GetCost() => pizza.GetCost() + 80;
    }

    public class PaneerDecorator : PizzaDecorator
    {
        public PaneerDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription() =>
            pizza.GetDescription() + ", Paneer";

        public override double GetCost() => pizza.GetCost() + 60;
    }
}
