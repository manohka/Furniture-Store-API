namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.ConcreteComponent
{
    public class Margherita : IPizza
    {
        public string GetDescription() => "Margherita";
        public double GetCost() => 200;
    }
}
