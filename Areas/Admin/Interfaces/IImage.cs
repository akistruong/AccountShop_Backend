namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IImage
    {
        public List<Models.TblImage> Select();
        public Models.TblImage Select(int id);
        public List<Models.TblImage> SelectImagesByProduct(string id);
        public Models.TblImage InsertToDatabase(Models.TblImage image);
        public Models.TblImage UpdateToDatabase(Models.TblImage image); 
        public bool Delete(int id);  
    }
}
