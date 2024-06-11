﻿namespace AccountShop.Models
{
    public partial class Option
    {
        public int OptionID { get; set; }   
        public string OptionName { get; set; } = string.Empty;
        public string ProductID { get; set; } = string.Empty;
        public virtual Product Product { get; set; } = new Product();
        public virtual ICollection<OptionValue> OptionValues { get; set; } = new List<OptionValue>();

    }
}