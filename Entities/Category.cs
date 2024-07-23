using AccountShop.Abtractions.Entity;
using System.ComponentModel.DataAnnotations;

namespace AccountShop.Entities
{
    public class Category : IEntity<int>
    {
        [MaxLength(100)]
        public string? CategoryName { get; set; }

        public string? CategoryImage { get; set; }

        public int? CategoryRootId { get; set; }

        public virtual Category? CategoryRoot { get; set; }

        public virtual ICollection<Category> InverseCategoryRoot { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}