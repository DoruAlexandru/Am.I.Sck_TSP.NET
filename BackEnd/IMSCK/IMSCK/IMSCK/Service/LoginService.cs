using IMSCK.Auth;
using IMSCK.DAO;
using IMSCK.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IMSCK.Service
{
    public class LoginService
    {

        ILoginDAO loginDAO;
        private readonly JwtSettings jwtSettings;

        public LoginService()
        {
            this.loginDAO = new LoginDAO();
            this.jwtSettings = Startup.jwtSettings;
        }

        public async Task<ServiceResponse<Dictionary<string,string>>> loginCheck(LoginDTO credentials)
        {
            ServiceResponse<Dictionary<string, string>> response = new ServiceResponse<Dictionary<string, string>>();
            bool loginCheck = await loginDAO.loginCheck(credentials);
            if (loginCheck)
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor {

                    Subject = new ClaimsIdentity(new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, credentials.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("token", tokenHandler.WriteToken(token));

                response.Data = data;
                return response;
            }

            return response;
        }

    }
}
