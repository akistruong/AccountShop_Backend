using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class Product : IEntity<string>
    {
        public static int IdLength = 20;
        public static int NameLength = 50;

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string? ProductImage { get; set; }

        public string? ProductDesciption { get; set; }

        public string? ProductSlug { get; set; }

        public int CategoryId { get; set; }

        public string? ProductContent { get; set; }

        public string? RootId { get; set; }

        public virtual Product? Root { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Product>? InverseRoot { get; set; } = new List<Product>();

        public virtual ICollection<Image>? TblImages { get; set; } = new List<Image>();

        public virtual ICollection<Variant>? Variants { get; set; } = new List<Variant>();

        public virtual ICollection<Option>? Options { get; set; } = new List<Option>();

        public virtual ICollection<Iventory>? Iventories { get; set; } = new List<Iventory>();
    }
}