namespace AccountShop.Models
{
    public  partial class OptionValue
    {
        public string OptionValueID { get; set; } 
        public string OptionID { get; set; } 
        public string OptionValueName { get; set; } = string.Empty;
        public Option?Option {  get; set; } 
        public virtual ICollection<VariantAttribute> VariantAttributes { get; set; } = new List<VariantAttribute>();

    }
}
