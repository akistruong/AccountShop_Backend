using AccountShop.Abtractions.Entity;
using System.ComponentModel.DataAnnotations;

namespace AccountShop.Entities
{
    public class OptionValue : IEntity<int>
    {
        public string OptionID { get; set; }

        [MaxLength(50)]
        public string OptionValueName { get; set; } = string.Empty;

        public Option? Option { get; set; }
        public virtual ICollection<VariantAttribute> VariantAttributes { get; set; } = new List<VariantAttribute>();
    }
}