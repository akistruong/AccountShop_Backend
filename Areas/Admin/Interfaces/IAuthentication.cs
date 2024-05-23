namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IAuthentication
    {
        public Dtos.AuthResponseDto Login(Models.TblUser user);
        public Dtos.AuthResponseDto Register(Models.TblUser user);
        public Models.TblUser GetUser(Models.TblUser user);

    }
}
