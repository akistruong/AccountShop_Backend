namespace AccountShop.Areas.Admin.Interfaces
{
    public interface ICategory
    {
        public List<Models.Category> Get();
        public Models.Category Get(int id);
        public Models.Category InsertToDatabase(Models.Category category);
        public Models.Category UpdateToDatabase(Models.Category category);
        public bool Delete(int id);
    }
}
