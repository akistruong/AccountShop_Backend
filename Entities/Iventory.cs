using AccountShop.Abtractions.Entity;

namespace AccountShop.Entities
{
    public class Iventory : IEntity<int>
    {
        public string ProductID { get; set; }
        public int BranchID { get; set; }
        public virtual Branch? Branch { get; set; }
        public int Qty { get; set; }
        public virtual Product? Product { get; set; }
    }
}