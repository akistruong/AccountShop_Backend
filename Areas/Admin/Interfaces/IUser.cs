namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IUser
    {
        public List<Models.TblUser> Select();
        public Models.TblUser Select(string id);
        public Models.TblUser Insert(Models.TblUser user);
        public Models.TblUser Update(Models.TblUser user);
        public bool Delete(string id);

    }
}
