using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Composite
{
    // Composite: Collection of furniture items
    public class FurnitureCollection : IFurnitureComponent
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private List<IFurnitureComponent> _children = new List<IFurnitureComponent>();

        public FurnitureCollection(
            string name,
            string description)
        {
            Name = name;
            Description = description;

            Logger.GetInstance().Log(
                $"Composite: Created composite collection " +
                $"- {name}");
        }

        // Add child (Leaf or Composite)
        public void Add(IFurnitureComponent component)
        {
            _children.Add(component);

            Logger.GetInstance().Log(
                $"Composite: Added {component.GetName()} " +
                $"to {Name}");
        }

        // Remove child
        public void Remove(IFurnitureComponent component)
        {
            _children.Remove(component);

            Logger.GetInstance().Log(
                $"Composite: Added {component.GetName()} " +
                $"to {Name}");
        }

        // Get all children
        public List<IFurnitureComponent> GetChildren()
        {
            return new List<IFurnitureComponent>(_children);
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return Description;
        }

        // Recursive: Sum of all children prices

        public decimal GetPrice()
        {
            return _children.Sum(c => c.GetPrice());
        }

        // Recursive: Sum of all children quantities
        public int GetQuantity()
        {
            return _children.Sum(c => c.GetQuantity());
        }

        // Recursive: Sum of all children weights
        public double GetWeight()
        {
            return _children.Sum(c => c.GetWeight());
        }

        // Recursive: Total price (price × quantity)
        public decimal GetTotalPrice()
        {
            return _children.Sum(c => c.GetTotalPrice());
        }

        // // Recursive: Display tree structure
        public void Display(int indent = 0)
        {
            string indentStr = new string(' ', indent);
            Console.WriteLine(
                $"{indentStr} {Name}");
            Console.WriteLine(
                $"{indentStr}   Description: {Description}");
            Console.WriteLine(
                $"{indentStr}   Items: {GetQuantity()}, " +
                $"Total Weight: {GetWeight()}kg, " +
                $"Total Price: ${GetTotalPrice():F2}");

            foreach (var child in _children)
            {
                child.Display(indent + 3);
            }
        }

        // Get all items recursively
        public List<FurnitureItem> GetAllItems()
        {
            var items = new List<FurnitureItem>();

            foreach (var child in _children)
            {
                if (child is FurnitureItem item)
                {
                    items.Add(item);
                }
                else if (child is FurnitureCollection collection)
                {
                    items.AddRange(collection.GetAllItems());
                }
            }

            return items;
        }
    }
}
