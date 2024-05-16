namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IVariant
    {
        public List<Models.Variant> Get();
        public Models.Variant Get(int id);
        public List<Models.Variant> GetByProduct(string id);
        public Models.Variant InsertToDatabase (Models.Variant variant);
        public Models.Variant UpdateToDatabase(Models.Variant variant);
        public bool Delete(int id); 
    }
}
