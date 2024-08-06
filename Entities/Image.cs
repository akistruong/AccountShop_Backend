using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class Image : IEntity<int>
    {
        public string? ImageUrl { get; set; }

        public string? ImageDsc { get; set; }

        public string? ProductId { get; set; }
        public int? VariantId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Variant? Variant { get; set; }
    }
}