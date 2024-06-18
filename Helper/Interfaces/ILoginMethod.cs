using AccountShop.Models;

namespace AccountShop.Helper.Interfaces
{
    public interface ILoginMethod
    {
        Response Login(TblUser user);
    }
}
