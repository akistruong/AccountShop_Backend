using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class PaymentMethod : IEntity<int>
    {
        public string? MethodName { get; set; }

        public string? MethodDsc { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}