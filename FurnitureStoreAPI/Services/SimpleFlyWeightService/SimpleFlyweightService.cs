using FurnitureStoreAPI.Models.SimpleFlyWeight.cs;
using FurnitureStoreAPI.Patterns.Singleton;
using FurnitureStoreAPI.Patterns.StructuralPatterns.Flyweight.Simple;

namespace FurnitureStoreAPI.Services.SimpleFlyWeightService
{
    public class SimpleFlyweightService
    {
        private List<Shape> _shapes = new();
        private ColorFactory _colorFactory = new ColorFactory();
        private int _shapeIdCounter = 1;

        public void CreateShapes(int count,
            string colorName,
            string hexCode)
        {
            // Get color from factory
            // (creates if new, reuses if exists)
            var color = _colorFactory.GetColor(colorName, hexCode);

            Logger.GetInstance().Log(
                $"Service: Creating {count} shapes " +
                $"with color {colorName}");

            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                var shape = new Shape(
                    _shapeIdCounter++,
                    random.Next(0, 800),
                    random.Next(0, 600),
                    random.Next(10, 50),
                    color
                    );

                _shapes.Add(shape);
            }
        }

        public int GetTotalShapes()
        {
            return _shapes.Count;
        }

        public int GetUniqueColors()
        {
            return _colorFactory.GetPoolSize();
        }

        public List<ShapeResponse> GetAllShapes()
        {
            return _shapes.Select(s =>
                new ShapeResponse
                {
                    Id = s.Id,
                    X = s.X,
                    Y = s.Y,
                    Size = s.Size,
                    Color = s.Color.Name
                }).ToList();
        }

        public void DisplayAllShapes()
        {
            Console.WriteLine(
                "\n═══════════════════════════════════");
            Console.WriteLine("📋 All Shapes:");
            Console.WriteLine(
                "═══════════════════════════════════");

            foreach (var shape in _shapes)
            {
                shape.Draw();
            }

            _colorFactory.DisplayPool();

            Console.WriteLine(
                $"\n📊 Total Shapes: {_shapes.Count}");
            Console.WriteLine(
                $"🎨 Unique Colors: {_colorFactory.GetPoolSize()}");
            Console.WriteLine(
                "═══════════════════════════════════\n");
        }

        public SimpleFlyweightStatsResponse
            GetStats()
        {
            return new SimpleFlyweightStatsResponse
            {
                TotalShapes = GetTotalShapes(),
                UniqueColors = GetUniqueColors(),
                Message =
                    "Simple Flyweight Pattern Stats"
            };
        }

        public void Clear()
        {
            _shapes.Clear();
            _shapeIdCounter = 1;
            Logger.GetInstance().Log(
                "Service: Cleared all shapes");
        }

    }
}
