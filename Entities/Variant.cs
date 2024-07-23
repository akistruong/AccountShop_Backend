using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class Variant : IEntity<int>
    {
        public string ProductId { get; set; }
        public decimal VariantPrice { get; set; }
        public string VariantSlug { get; set; }
        public int VariantQty { get; set; }
        public string? VariantName { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Variant? VariantRoot { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<VariantAttribute> VariantAttributes { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}