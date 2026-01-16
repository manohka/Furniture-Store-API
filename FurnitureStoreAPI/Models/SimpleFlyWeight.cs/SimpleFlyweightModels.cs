namespace FurnitureStoreAPI.Models.SimpleFlyWeight.cs
{
    /*public class SimpleFlyweightModels
    {
    }*/

    public class CreateShapesRequest
    {
        public int Count { get; set; }
        public string ColorName { get; set; }
        public string HexCode { get; set; }
    }

    public class ShapeResponse
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
    }

    public class SimpleFlyweightStatsResponse
    {
        public int TotalShapes { get; set; }
        public int UniqueColors { get; set; }
        public string Message { get; set; }
    }
}
