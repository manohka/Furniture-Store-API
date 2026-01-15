namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Composite
{
    // Component Interface - Can be Leaf or Composite
    public interface IFurnitureComponent
    {
        string GetName();
        decimal GetPrice();
        int GetQuantity();
        double GetWeight();
        string GetDescription();
        void Display(int indent = 0);
        decimal GetTotalPrice();
    }
}
