using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices_Jwt_1.Middleware
{
    public class AuthMiddleware
    {
        public static IServiceCollection AddTokkenAuthentication(IServiceCollection services, IConfiguration config)
        {
            var secret = config.GetSection("JWTCons").GetSection("Secret").Value;
            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidIssuer = "localhost",
                   ValidAudience = "localhost"
               };
            });

            return services;
        }
    }
}
