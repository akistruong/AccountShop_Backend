using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Helper.Interfaces;
using AccountShop.Models;

namespace AccountShop.Helper
{
    public class PhoneLogin : ILoginMethod
    {
        UserDAO _userDAO;

        public PhoneLogin(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public Response Login(TblUser user)
        {
            Response response = new Response();
            response.code = 200;
            response.message = "Login with phone.";
            response.metadata = null;
            return response;
        }
    }
}
