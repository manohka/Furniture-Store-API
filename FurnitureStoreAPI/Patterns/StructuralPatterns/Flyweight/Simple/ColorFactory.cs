namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Flyweight.Simple
{
    // Flyweight Factory: Creates and caches colors
    public class ColorFactory
    {
        private Dictionary<string, Color> _colorPool = new();

        public Color GetColor(string colorName, string hexCode)
        {
            // check if color already exists
            if (_colorPool.ContainsKey(colorName))
            {
                Console.WriteLine(
                    $"♻️  Reusing cached color '{colorName}'");
                return _colorPool[colorName];
            }

            // create a new color
            var color = new Color(colorName, hexCode);
            _colorPool[colorName]  = color;

            return color;
        }

        public int GetPoolSize()
        {
            return _colorPool.Count;
        }

        public void DisplayPool()
        {
            Console.WriteLine(
                $"\n📊 Color Pool Size: {_colorPool.Count}");

            foreach ( var color in _colorPool.Values )
            {
                Console.WriteLine(
                    $"   - {color.Name} ({color.HexCode})");
            }
        }
    }
}
