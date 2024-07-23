using AccountShop.Abtractions.Entity;
using System.ComponentModel.DataAnnotations;

namespace AccountShop.Entities
{
    public class Branch : IEntity<int>
    {
        [MaxLength(100)]
        public string BranchName { get; set; }

        public string? BranchDsc { get; set; }
        public virtual ICollection<Iventory> Iventories { get; set; } = new List<Iventory>();
    }
}