namespace AccountShop.Models
{
    public partial class VariantAttribute
    {
        public int AttributeId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int VariantId { get; set; }  
        public virtual Models.Variant Variant { get; set; }
    }
}
