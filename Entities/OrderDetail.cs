namespace AccountShop.Entities
{
    public class OrderDetail
    {
        public int? OdtQty { get; set; }

        public decimal? OdtPrice { get; set; }

        public int VariantId { get; set; }

        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Variant Variant { get; set; } = null!;
    }
}