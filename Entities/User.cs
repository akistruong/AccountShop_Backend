using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class User : IEntity<string>
    {
        public static int IdLength = 20;
        public static int PwdLength = 15;
        public static int EmailLength = 50;
        public string? Pwd { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}