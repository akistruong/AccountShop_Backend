using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AccountShop.Helper
{
    public class JwtHelper
    {
            private string secureKey = "$11$gZiyrvDsjDchQJpFpDN1t.UulusuFeizdaMP3cE1Kxu0CLQuunXT6";
        public string Generate(string userName)
        {

            string JWTKey = secureKey;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("$11$gZiyrvDsjDchQJpFpDN1t.UulusuFeizdaMP3cE1Kxu0CLQuunXT6"));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>
           {
                new Claim(ClaimTypes.NameIdentifier,userName),
            };

            var token = new JwtSecurityToken(JWTKey,
              JWTKey,
              claims: claims,
              expires: DateTime.Now.AddDays(1),
              
              signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secureKey);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
