using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class Order : IEntity<Guid>
    {
        public int? OrderQty { get; set; }

        public decimal? OrderPrice { get; set; }

        public bool? OrderStatus { get; set; }

        public int? PaymentMethodId { get; set; }

        public string? UserId { get; set; }

        public bool? Ischeckout { get; set; }

        public virtual ICollection<OrderDetail> Orderdetails { get; set; } = new List<OrderDetail>();

        public virtual PaymentMethod? PaymentMethod { get; set; }

        public virtual User? User { get; set; }
    }
}