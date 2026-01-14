using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Proxy
{
    // PROXY: Controls access, caches, applies discounts
    public class FurnitureAccessProxy : IFurnitureAccess
    {
        private RealFurnitureAccess _realAccess;
        private User _currentUser;

        private Dictionary<int, Furniture> _furniturecache = new();
        private List<Furniture> _allFurnitureCache;
        private Dictionary<int, decimal> _priceCache = new();

        // Access Tracking
        private List<AccessLog> _accessLogs = new();

        public FurnitureAccessProxy(User user)
        {
            _currentUser = user;
            Logger.GetInstance().Log(
                $"Proxy: Initialized for user " +
                $"{user.Username} ({user.MembershipType})");
        }

        // Load real object only when needed (Lazy Loading)
        private RealFurnitureAccess GetRealAccess()
        {
            if (_realAccess == null)
            {
                Logger.GetInstance().Log(
                    "Proxy: Creating real access object");
                _realAccess = new RealFurnitureAccess();
            }

            return _realAccess;
        }

        // Check access control
        private void CheckAccess(int furnitureId)
        {
            var furniture = GetRealAccess()
                .GetFurniture( furnitureId );

            if(furniture is PremiumFurniture premium && premium.IsExclusive)
            {
                if (_currentUser.MembershipType == MembershipType.Regular)
                {
                    throw new UnauthorizedAccessException(
                        $"This exclusive furniture " +
                        $"({premium.Name}) is only available " +
                        $"to Premium members");
                }
            }

            Logger.GetInstance().Log(
                $"Proxy: Access granted to user " +
                $"{_currentUser.Username}");
        }

        // TO BE CONTINUED FROM HERE

        public Furniture GetFurniture(int furnitureId)
        {
            Logger.GetInstance().Log(
                $"Proxy: GetFurniture called for ID {furnitureId}");

            // Check access first
            CheckAccess(furnitureId);

            // check cache
            if(_furniturecache.ContainsKey(furnitureId))
            {
                Logger.GetInstance().Log(
                    $"Proxy: Returning cached furniture " +
                    $"{furnitureId}");
                LogAccess(_currentUser.UserId, furnitureId);
                return _furniturecache[furnitureId];
            }

            // Get from real object
            Logger.GetInstance().Log(
                $"Proxy: Fetching from database");
            var furniture = GetRealAccess()
                .GetFurniture(furnitureId);

            if (furniture != null)
            {
                // cache it
                _furniturecache[furnitureId] = furniture;
                Logger.GetInstance().Log(
                    $"Proxy: Cached furniture {furnitureId}");
            }
            LogAccess(_currentUser.UserId, furnitureId);
            return furniture;
        }

        public List<Furniture> GetAllFurniture()
        {
            Logger.GetInstance().Log(
                "Proxy: GetAllFurniture called");

            // Check cache
            if (_allFurnitureCache != null)
            {
                Logger.GetInstance().Log(
                    "Proxy: Returning cached all furniture");
                return _allFurnitureCache;
            }

            // Get from real object
            Logger.GetInstance().Log(
                "Proxy: Fetching all furniture from database");
            var allFurniture = GetRealAccess()
                .GetAllFurniture();

            // Filter based on access
            var accessibleFurniture = allFurniture
                .Where(f =>
                {
                    if (f is PremiumFurniture premium
                    && premium.IsExclusive)
                    {
                        return _currentUser.MembershipType != MembershipType.Regular;
                    }
                    return true;
                }).ToList();

            // cache it
            _allFurnitureCache = accessibleFurniture;
            Logger.GetInstance().Log(
                $"Proxy: Cached {accessibleFurniture.Count} " +
                $"furniture items");

            return accessibleFurniture;
        }

        public decimal GetPrice(int furnitureId)
        {
            Logger.GetInstance().Log(
                $"Proxy: GetPrice called for ID {furnitureId}");

            // Check access
            CheckAccess(furnitureId);

            // Check cache
            if (_priceCache.ContainsKey(furnitureId))
            {
                Logger.GetInstance().Log(
                    $"Proxy: Returning cached price " +
                    $"for {furnitureId}");
                return _priceCache[furnitureId];
            }

            // Get original price
            var originalPrice = GetRealAccess()
                .GetPrice(furnitureId);

            // Apply discount
            var finalPrice = ApplyDiscount(originalPrice);

            // Cache it
            _priceCache[furnitureId] = finalPrice;
            Logger.GetInstance().Log(
                $"Proxy: Cached price for {furnitureId}");

            return finalPrice;
        }

        // Apply discount based on membership
        private decimal ApplyDiscount(decimal price)
        {
            decimal discount = _currentUser.MembershipType
                switch
            {
                MembershipType.Regular => 0,
                MembershipType.Premium => price * 0.1m, // 10%
                MembershipType.VIP => price * 0.2m, // 20%
                _ => 0
            };

            if (discount > 0)
            {
                Logger.GetInstance().Log(
                    $"Proxy: Applied {discount:F2} " +
                    $"discount for {_currentUser.MembershipType} " +
                    $"member");
            }

            return price - discount;
        }

        public void LogAccess(int userId, int furnitureId)
        {
            var log = new AccessLog
            {
                UserId = userId,
                FurnitureId = furnitureId,
                AccessTime = DateTime.UtcNow,
                MembershipType = _currentUser.MembershipType.ToString()
            };

            _accessLogs.Add(log);

            Logger.GetInstance().Log(
                $"Proxy: Access logged for user {userId}");
        }

        public List<AccessLog> GetAccessLogs()
        {
            return new List<AccessLog>(_accessLogs);
        }

        public void ClearCache()
        {
            _furniturecache.Clear();
            _allFurnitureCache = null;
            _priceCache.Clear();
            Logger.GetInstance().Log("Proxy: Cache cleared");
        }

        public class AccessLog
        {
            public int UserId { get; set; }
            public int FurnitureId { get; set; }
            public DateTime AccessTime { get; set; }
            public string MembershipType { get; set; }
        }
    }
}
