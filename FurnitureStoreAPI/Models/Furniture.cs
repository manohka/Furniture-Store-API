namespace FurnitureStoreAPI.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"Furniture: {Name}, Style: {Style}, Price: ${Price}, "
                + $"Material: {Material}, Color: {Color}";
        }
    }

    public class FurnitureOrder
    {
        public int OrderId { get; set; }
        public List<Furniture> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
