using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Patterns.AbstractFactory;
using FurnitureStoreAPI.Patterns.Builder;
using FurnitureStoreAPI.Patterns.FactoryMethod;
using FurnitureStoreAPI.Patterns.Prototype;
using FurnitureStoreAPI.Patterns.Singleton;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Adapter;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Facade;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Proxy;

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
            if (original == null)
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

        // STRUCTURAL DESIGN PATTERNS
        // ADAPTER PATTERN   12/01/2026

        public List<Furniture> GetFurnitureFromSupplier(string supplier)
        {
            IFurnitureSupplier supplierAdapter = supplier.ToLower() switch
            {
                "ikea" => new IKEAAdapter(),
                "ashley" => new AshleyFurnitureAdapter(),
                "wayfair" => new WayfairAdapter(),
                _ => throw new ArgumentException("Unknown Supplier")
            };

            var furniture = supplierAdapter.GetFurnitureList();

            // Add supplier info to each item
            foreach (var item in furniture)
            {
                item.Supplier = supplier;
            }

            // Add to inventory (consistent with other patterns)
            _furnitureInventory.AddRange(furniture);

            Logger.GetInstance().Log($"Fetched and added {furniture.Count} items from {supplier}");

            return furniture;
        }

        // Get all suppliers in inventory
        public List<string> GetAllSuppliers()
        {
            return _furnitureInventory.
                Select(f => f.Supplier)
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct()
                .ToList();
        }

        // Get furniture by supplier
        public List<Furniture> GetFurnitureBySupplier(string supplier)
        {
            return _furnitureInventory
                .Where(f => f.Supplier?.ToLower() == supplier.ToLower())
                .ToList();
        }

        // Facade Pattern
        public OrderResponse PlaceOrder(OrderRequest request, Furniture furniture)
        {
            var orderFacade = new OrderFacade();
            return orderFacade.PlaceOrder(request, furniture);
        }

        // PROXY PATTERN:

        public Furniture GetFurnitureWithProxy(
            User user, int furnitureId)
        {
            var proxy = new FurnitureAccessProxy(user);
            var furniture = proxy.GetFurniture(furnitureId);

            Logger.GetInstance().Log(
        $"Service: Retrieved furniture for user " +
        $"{user.Username}");

            return furniture;
        }

        public List<Furniture> GetAllFurnitureWithProxy(User user)
        {
            var proxy = new FurnitureAccessProxy(user);
            var furniture = proxy.GetAllFurniture();

            Logger.GetInstance().Log(
        $"Service: Retrieved all furniture for user " +
        $"{user.Username}");

            return furniture;
        }

        public decimal GetPriceWithProxy(User user, int furnitureId)
        {
            var proxy = new FurnitureAccessProxy(user);
            return proxy.GetPrice(furnitureId);
        }

        // BRIDGE Pattern - Create furniture with specific material

        // CONTINUE FROM HERE

        public FurnitureSpecification CreateBridgeFurniture(
            string furnitureType,
            string materialType)
        {
            IMaterialProduction material = materialType.ToLower() switch
            {
                "wood" => new WoodProduction(),
                "metal" => new MetalProduction(),
                "leather" => new LeatherProduction(),
                "fabric" => new FabricProduction(),
                _ => throw new ArgumentException("Unknown material type")
            };

            // Create abstraction with bridge
            BridgeFurniture furniture = furnitureType.ToLower() switch
            {
                "chair" => new Chair(material),
                "table" => new Table(material),
                "sofa" => new Sofa(material),
                "bed" => new Bed(material),
                _ => throw new ArgumentException(
                    "Unknown furniture type")
            };

            Logger.GetInstance().Log(
        $"Bridge: Created {furnitureType} with {materialType}");

            return furniture.GetSpecification();
        }

        // Bridge Pattern - Change material at runtime
        public FurnitureSpecification ChangeFurnitureMaterial(
            string furnitureType,
            string currentMaterial,
            string newMaterial)
        {
            // Create with current material
            IMaterialProduction currentMat = currentMaterial
                .ToLower() switch
            {
                "wood" => new WoodProduction(),
                "metal" => new MetalProduction(),
                "leather" => new LeatherProduction(),
                "fabric" => new FabricProduction(),
                _ => throw new ArgumentException(
                    "Unknown material type")
            };

            BridgeFurniture furniture = furnitureType
                .ToLower() switch
            {
                "chair" => new Chair(currentMat),
                "table" => new Table(currentMat),
                "sofa" => new Sofa(currentMat),
                "bed" => new Bed(currentMat),
                _ => throw new ArgumentException(
                    "Unknown furniture type")
            };

            // Change to new material
            IMaterialProduction newMat = newMaterial.ToLower() switch
            {
                "wood" => new WoodProduction(),
                "metal" => new MetalProduction(),
                "leather" => new LeatherProduction(),
                "fabric" => new FabricProduction(),
                _ => throw new ArgumentException(
                    "Unknown material type")
            };

            furniture.SetMaterialProduction(newMat);

            Logger.GetInstance().Log(
        $"Bridge: Changed {furnitureType} material " +
        $"from {currentMaterial} to {newMaterial}");

            return furniture.GetSpecification();
        }

        // Get all possible combinations
        public List<dynamic> GetAllBridgeCombinations()
        {
            var furnitureTypes = new[]
            { "chair", "table", "sofa", "bed" };

            var materials = new[]
            { "wood", "metal", "leather", "fabric" };

            var combinations = new List<dynamic>();

            foreach ( var furniture in furnitureTypes )
            {
                foreach ( var material in materials )
                {
                    try
                    {
                        var spec = CreateBridgeFurniture(
                            furniture, material);

                        combinations.Add(new
                        {
                            furnitureType = furniture,
                            materialType = material,
                            price = spec.TotalPrice
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return combinations;
        }
    }
}
