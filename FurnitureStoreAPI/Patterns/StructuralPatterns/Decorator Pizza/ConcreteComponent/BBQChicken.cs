namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Decorator_Pizza.ConcreteComponent
{
    public class BBQChicken : IPizza
    {
        public string GetDescription() => "BBQChicken";
        public double GetCost() => 200;
    }
}
