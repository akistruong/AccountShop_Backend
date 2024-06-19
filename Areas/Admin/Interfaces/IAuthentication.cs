namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IAuthentication
    {
        public Response Login(Models.TblUser user);
        public Response Register(Models.TblUser user);
        public Response GetUser();

    }
}
