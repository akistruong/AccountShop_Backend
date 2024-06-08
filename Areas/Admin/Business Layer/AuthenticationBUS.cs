using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;


namespace AccountShop.Areas.Admin.Business_Layer
{
    public class AuthenticationBUS : IAuthentication
    {
        UserDAO UserDAO;
        public AuthenticationBUS(AccountShopContext context) { 
            UserDAO = new UserDAO(context);    
        }
        [Authorize]
        public TblUser GetUser(TblUser user)
        {
            JwtHelper jwt = new JwtHelper();
            return user;
        }

        public Dtos.AuthResponseDto Login(TblUser user)
        {
            JwtHelper jwt = new JwtHelper();
            var User = UserDAO.Select(user.Username);
            if (User != null)
            {
            var isPassword = HashHelper.Decode(user.Pwd, User.Pwd);
                if(isPassword)
                {
                    
                    jwt.Generate(user.Username);
                }
            }
            Dtos.AuthResponseDto response = new Dtos.AuthResponseDto();
            response.code = "200";
            response.message = "Login success";
            response.key = jwt.Generate(user.Username); 
            return response;
        }

        public Dtos.AuthResponseDto Register(TblUser user)
        {
            JwtHelper jwt = new JwtHelper();
            var User = UserDAO.Select(user.Username);
            Dtos.AuthResponseDto response = new Dtos.AuthResponseDto();
            if (User == null)
            {
               user.Pwd = HashHelper.Encode(user.Pwd);
                UserDAO.Insert(user);
                
                response.code = "200";
                response.message = "Login success";
                response.key = jwt.Generate(user.Username); response.key = jwt.Generate(user.Username);
                return response;
            }
            response.code = "404";
            response.message = "Login faild";
            return response;
        }
    }
}
