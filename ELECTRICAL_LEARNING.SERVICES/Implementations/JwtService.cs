using ElectricalLearning.Repositories.Entities;
using ElectricalLearning.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Account account)
        {
            var jwtSettings = _config.GetSection("JwtSettings");

            var secretKey = jwtSettings["Secret"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiresInMinutes = jwtSettings["ExpiresInMinutes"];

            // Validate config values (optional)
            if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
            {
                throw new Exception("JWT configuration values are missing.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Email, account.Email ?? ""),
                new Claim(ClaimTypes.Role, account.Role ?? ""),
                new Claim("FullName", account.FullName ?? "")
        };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.TryParse(expiresInMinutes, out var minutes) ? minutes : 60),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
