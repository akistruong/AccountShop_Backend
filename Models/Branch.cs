namespace AccountShop.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string? BranchDsc { get; set; }
        public virtual ICollection<Iventory> Iventories { get; set; } = new List<Iventory>();

    }
}
