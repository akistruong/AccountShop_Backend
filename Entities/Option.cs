using AccountShop.Abtractions.Entity;
using System.ComponentModel.DataAnnotations;

namespace AccountShop.Entities
{
    public class Option : IEntity<string>
    {
        [MaxLength(30)]
        public override string Id { get => base.Id; set => base.Id = value; }

        public static int NameLength = 30;
        public string OptionName { get; set; }
        public string ProductID { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<OptionValue> OptionValues { get; set; } = new List<OptionValue>();
    }
}