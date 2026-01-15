namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.ConcreteComponent
{
    public class Pepperoni : IPizza
    {
        public string GetDescription() => "Pepperoni";
        public double GetCost() => 180;
    }
}
