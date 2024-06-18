using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Helper.Interfaces;
using AccountShop.Models;

namespace AccountShop.Helper
{
    public class DefaultLogin : ILoginMethod
    {
        UserDAO _userDAO;

        public DefaultLogin(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public Response Login(TblUser user)
        {
            JwtHelper jwt = new JwtHelper();
            Response response = new Response();
            var User = _userDAO.Select(user.Username);
            if (User != null)
            {
                if (user.Pwd != null && User.Pwd != null)
                {

                    var isPassword = HashHelper.Decode(user.Pwd, User.Pwd);
                    if (isPassword)
                    {

                        response.code = 200;
                        response.message = "Login success";
                        response.metadata = jwt.Generate(user.Username);
                        return response;
                    }
                }

            }

            response.code = 404;
            response.message = "User is notfound";
            response.metadata = null;
            return response;
        }
    }
}
