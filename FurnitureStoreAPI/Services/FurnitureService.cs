using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Patterns.AbstractFactory;
using FurnitureStoreAPI.Patterns.Builder;
using FurnitureStoreAPI.Patterns.FactoryMethod;
using FurnitureStoreAPI.Patterns.Prototype;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Services
{
    public class FurnitureService
    {
        private List<Furniture> _furnitureInventory = new();
        private int _nextId = 1;
        public FurnitureService()
        {
            InitializeInvenntory();
        }

        private void InitializeInvenntory()
        {
            Logger.GetInstance().Log("Initializing Furniture Inventory");
            _furnitureInventory.Add(new Furniture
            {
                Id = _nextId++,
                Name = "Office Chair",
                Style = "Modern",
                Price = 200,
                Material = "Mesh",
                Color = "Black"
            });
        }

        // Builder Patternn
        public Furniture CreateCustomFurniture(
            string name,
            string style,
            decimal price,
            string material,
            string color)
        {
            var furniture = new FurnitureBuilder()
                .SetName(name)
                .SetStyle(style)
                .SetPrice(price)
                .SetMaterial(material)
                .SetColor(color)
                .Build();

            furniture.Id = _nextId++;

            _furnitureInventory.Add(furniture);

            Logger.GetInstance()
                .Log($"Created custom furniture: {name}");

            return furniture;
        }

        // Factory Method
        public Furniture CreateFurnitureByType(string type)
        {
            IFurnitureFactory factory = type.ToLower() switch
            {
                "chair" => new ChairFactory(),
                "sofa" => new SofaFactory(),
                "table" => new TableFactory(),
                _ => throw new ArgumentException("Unknown Type")
            };

            var furniture = factory.CreateFurniture();

            furniture.Id = _nextId++;

            _furnitureInventory.Add(furniture);

            Logger.GetInstance().Log($"Created Furniture using Factory: {type}");
            return furniture;
        }

        // Abstract Factory

        public List<Furniture> CreateFurnitureSet(string style)
        {
            IStyleFurnitureFactory factory = style.ToLower() switch
            {
                "modern" => new ModernFurnitureFactory(),
                "victorian" => new VictorianFurnitureFactory(),
                _ => throw new ArgumentException("Unknown Style")
            };

            var chair = factory.CreateChair();
            var table = factory.CreateTable();
            var sofa = factory.CreateSofa();

            chair.Id = _nextId++;
            table.Id = _nextId++;
            sofa.Id = _nextId++;

            _furnitureInventory.AddRange(
                new[] { chair, table, sofa });

            Logger.GetInstance()
                .Log($"Created furniture set: {style}");

            return new List<Furniture> { chair, table, sofa };
        }

        // Prototype Pattern

        public Furniture CloneFurniture(int id)
        {
            var original = _furnitureInventory
                .FirstOrDefault(f => f.Id == id);
            if(original == null)
            {
                throw new KeyNotFoundException(
                    $"Furniture with id {id} not found");
            }

            var prototype = new FurniturePrototype(original);
            var cloned = prototype.Clone();
            cloned.Id = _nextId++;

            _furnitureInventory.Add(cloned);

            Logger.GetInstance().Log($"Cloned furniture: {original.Name}");

            return cloned;
        }

        // Get all Furniture

        public List<Furniture> GetAllFurnitures()
        {
            return _furnitureInventory;
        }

        // Get furniture by Id
        public Furniture GetFurnitureById(int id)
        {
            return _furnitureInventory.FirstOrDefault(f => f.Id == id);
        }

    }
}
