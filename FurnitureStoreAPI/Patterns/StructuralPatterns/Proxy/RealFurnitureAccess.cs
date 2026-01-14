using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Proxy
{
    // Real Subject - Expensive to create/access
    public class RealFurnitureAccess : IFurnitureAccess
    {
        private List<Furniture> _furnitureDatabase;
        private List<PremiumFurniture> _premiumDatabase;

        public RealFurnitureAccess()
        {
            Logger.GetInstance().Log(
                "RealFurnitureAccess: Loading from database " +
                "(expensive operation)");
            System.Threading.Thread.Sleep(1000);
            // Simulate expensive DB call

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _furnitureDatabase = new List<Furniture>
            {
                new Furniture
                {
                    Id = 1,
                    Name = "Standard Chair",
                    Style = "Modern",
                    Price = 150,
                    Material = "Wood",
                    Color = "Black"
                },

                new Furniture
                {
                    Id = 2,
                    Name = "Basic Table",
                    Style = "Contemporary",
                    Price = 300,
                    Material = "Glass",
                    Color = "Clear"
                }
            };

            _premiumDatabase = new List<PremiumFurniture>
            {
                new PremiumFurniture
                {
                    Id = 101,
                    Name = "Designer Leather Sofa",
                    Style = "Luxury",
                    Price = 2500,
                    Material = "Italian Leather",
                    Color = "Cream",
                    IsExclusive = true,
                    PremiumPrice = 2000,
                    ExclusiveDescription =
                        "Handcrafted Italian leather sofa, " +
                        "available only to premium members"
                },
                new PremiumFurniture
                {
                    Id = 102,
                    Name = "Marble Top Executive Desk",
                    Style = "Executive",
                    Price = 3500,
                    Material = "Marble & Walnut",
                    Color = "White & Brown",
                    IsExclusive = true,
                    PremiumPrice = 2800,
                    ExclusiveDescription =
                        "Premium executive desk with marble top, " +
                        "exclusive to VIP members"
                },
                new PremiumFurniture
                {
                    Id = 103,
                    Name = "Crystal Chandelier Cabinet",
                    Style = "Luxury",
                    Price = 4000,
                    Material = "Crystal & Mahogany",
                    Color = "Gold",
                    IsExclusive = true,
                    PremiumPrice = 3200,
                    ExclusiveDescription =
                        "Exquisite crystal chandelier cabinet, " +
                        "limited edition"
                }
            };
        }

        public Furniture GetFurniture(int furnitureId)
        {
            // Simulate expensive DB query
            System.Threading.Thread.Sleep(500);

            var regular = _furnitureDatabase
                .FirstOrDefault(f => f.Id == furnitureId);
            if (regular != null)
                return regular;

            return _premiumDatabase
                .FirstOrDefault(f => f.Id == furnitureId);
        }

        public List<Furniture> GetAllFurniture()
        {
            System.Threading.Thread.Sleep(500);
            var all = new List<Furniture>(_furnitureDatabase);
            all.AddRange(_premiumDatabase);
            return all;
        }

        public decimal GetPrice(int furnitureId)
        {
            System.Threading.Thread.Sleep (500);
            var furniture = GetFurniture(furnitureId);

            return furniture?.Price ?? 0;
        }

        public void LogAccess(int userId, int furnitureId)
        {
            System.Threading.Thread.Sleep(200);
            Logger.GetInstance().Log(
                $"Database: Logged access for User {userId} " +
                $"to Furniture {furnitureId}");
        }
    }
}
