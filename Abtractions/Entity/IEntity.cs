namespace AccountShop.Abtractions.Entity
{
    public abstract class IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

        public DateTime? CreatedAT { get; set; }

        public DateTime? UpdatedAT { get; set; }
    }
}