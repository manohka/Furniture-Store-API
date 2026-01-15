using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Composite
{
    // Leaf: Individual Furniture Item
    public class FurnitureItem : IFurnitureComponent
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }

        public FurnitureItem(
            string name,
            decimal price,
            int quantity,
            double weight,
            string description,
            string material,
            string color)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Weight = weight;
            Description = description;
            Material = material;
            Color = color;

            Logger.GetInstance().Log(
                $"Composite: Created leaf item - {name}");
        }

        public string GetName()
        {
            return Name;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public double GetWeight()
        {
            return Weight;
        }

        public string GetDescription()
        {
            return Description;
        }

        public decimal GetTotalPrice()
        {
            return Price * Quantity;
        }

        public void Display(int indent = 0)
        {
            string indentStr = new string(' ', indent);
            Console.WriteLine(
                $"{indentStr} {Name} (Qty: {Quantity}) " +
                $"- ${GetTotalPrice():F2}");
            Console.WriteLine(
                $"{indentStr}   Material: {Material}, " +
                $"Color: {Color}, Weight: {Weight}kg");
        }
    }
}
