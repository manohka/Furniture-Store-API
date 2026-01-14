namespace FurnitureStoreAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public MembershipType MembershipType { get; set; }
    }

    public enum MembershipType
    {
        Regular,
        Premium,
        VIP
    }

    public class PremiumFurniture : Furniture
    {
        public bool IsExclusive { get; set; }
        public decimal PremiumPrice { get; set; }
        public string ExclusiveDescription { get; set; }
    }
}
