using Microsoft.Ajax.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace MVC_Test.Services
{
    public static class JWT
    {
        public static string GenerateToken(string name, string role) {
            var secret = WebConfigurationManager.AppSettings["JWTSecret"];
            var issuer = WebConfigurationManager.AppSettings["JWTIssuer"];
            var audience = WebConfigurationManager.AppSettings["JWTAudience"];

            if (string.IsNullOrEmpty(secret))
                return string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                { 
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role) 
                }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = issuer,
                Audience= audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static IPrincipal ValidateToken(string token) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return principal;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            var secret = WebConfigurationManager.AppSettings["JWTSecret"];
            var issuer = WebConfigurationManager.AppSettings["JWTIssuer"];
            var audience = WebConfigurationManager.AppSettings["JWTAudience"];

            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer, 
                ValidAudience=audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };
        }
    }
}