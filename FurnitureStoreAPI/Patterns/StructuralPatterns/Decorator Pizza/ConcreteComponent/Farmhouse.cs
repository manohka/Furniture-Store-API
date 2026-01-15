namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.ConcreteComponent
{
    public class Farmhouse : IPizza
    {
        public string GetDescription() => "Farmhouse";
        public double GetCost() => 150;
    }
}
