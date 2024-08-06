namespace AccountShop.Shared.DTOs
{
    public class ProductInsertRequestDto
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string? ProductImage { get; set; }

        public string? ProductDesciption { get; set; }

        public string? ProductSlug { get; set; }

        public int CategoryId { get; set; }

        public string? ProductContent { get; set; }

        public string? RootId { get; set; }
    }
}