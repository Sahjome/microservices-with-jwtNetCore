using MicroServices_Jwt_1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices_Jwt_1.Services
{
    public class JWTServices
    {
        private readonly string secret;
        private readonly string expiration;

        public JWTServices(IConfiguration config)
        {
            secret = config.GetSection("JWTCons").GetSection("Secret").Value;
            expiration = config.GetSection("JWTCons").GetSection("Expiration").Value;
        }

        public string GenerateToken(Student student)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, student.Name),
                }),
                Expires = DateTime.Now.AddSeconds(double.Parse(expiration)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
