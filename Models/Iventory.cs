namespace AccountShop.Models
{
    public partial class Iventory
    {
            public string ProductID { get; set; }
        public int BranchID { get; set; }
        public virtual Branch? Branch { get; set; }
        public int Qty { get; set; }
        public virtual Product? Product {  get; set; }            
    }
}
