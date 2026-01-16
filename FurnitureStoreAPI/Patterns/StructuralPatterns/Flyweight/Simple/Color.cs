namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Flyweight.Simple
{
    // Flyweight: The shared object (Intrinsic State)
    public class Color
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

        public Color(string name, string hexCode)
        {
            Name = name;
            HexCode = hexCode;
            Console.WriteLine(
                $"✓ Color '{name}' created (Shared)");
        }
    }
}
