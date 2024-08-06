using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class VariantAttribute : IEntity<int>
    {
        public int OptionValueID { get; set; }
        public int VariantId { get; set; }

        public virtual Variant? Variant { get; set; } = null!;
        public virtual OptionValue? OptionValue { get; set; } = null!;
    }
}