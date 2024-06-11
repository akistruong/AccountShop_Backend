namespace AccountShop.Models
{
    public  partial class OptionValue
    {
        public int OptionValueID { get; set; } 
        public int OptionID { get; set; } 
        public string OptionValueName { get; set; } = string.Empty;
        public Option Option {  get; set; }  = new Option();    
    }
}
