namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Flyweight.Simple
{
    // Context: Uses Flyweight (Color)
    // Extrinsic State: Position, Size
    public class Shape
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; } // Shared!

        public Shape(int id,
            int x,
            int y,
            int size,
            Color color)
        {
            Id = id;
            X = x;
            Y = y;
            Size = size;
            Color = color;
        }

        public void Draw()
        {
            Console.WriteLine(
                $"Shape {Id}: Position ({X},{Y}), " +
                $"Size {Size}, Color: {Color.Name}");
        }
    }
}
