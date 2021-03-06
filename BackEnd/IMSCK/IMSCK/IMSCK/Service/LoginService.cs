using IMSCK.Config;
using IMSCK.DAO;
using IMSCK.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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

        private readonly ILoginDao loginDAO;
        private readonly string jwtSecret;

        public LoginService(ILoginDao loginDAO)
        {
            this.loginDAO = loginDAO;
            
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            var section = config.GetSection(nameof(JwtConfig));
            var jwtConfig = section.Get<JwtConfig>();

            this.jwtSecret = jwtConfig.Secret;

        }

        public async Task<ServiceResponse<Dictionary<string,string>>> loginCheck(LoginDto credentials)
        {
            ServiceResponse<Dictionary<string, string>> response = new ServiceResponse<Dictionary<string, string>>();
            bool loginCheck = await loginDAO.loginCheck(credentials);
            if (loginCheck)
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                
                var key = Encoding.ASCII.GetBytes(this.jwtSecret);

                var tokenDescriptor = new SecurityTokenDescriptor {

                    Subject = new ClaimsIdentity(new[] {
                        new Claim("Username", credentials.Username),
                        new Claim(JwtRegisteredClaimNames.Sub, credentials.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(120),
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
