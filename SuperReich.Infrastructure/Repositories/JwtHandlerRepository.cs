using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;

namespace SuperReich.Infrastructure.Repositories
{
    public class JwtHandlerRepository(IConfiguration configuration) : IJwtHandlerRepository
    {
        private readonly IConfiguration _configuration = configuration;

        public JwtSecurityToken GenerateToken(User user)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(user.Rut)) claims.Add(new Claim(ClaimTypes.Name, user.Rut)); else throw new Exception("El usuario no tiene un Rut válido.");

            if (!string.IsNullOrEmpty(user.Names)) claims.Add(new Claim("Username", user.Names)); else throw new Exception("El usuario no tiene un nombre válido.");

            if (user.Roles != null && !string.IsNullOrEmpty(user.Roles.Rolename)) claims.Add(new Claim(ClaimTypes.Role, user.Roles.Rolename)); else throw new Exception("El usuario no tiene un rol válido.");

            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JwtSettings:DurationInMinutes"]!)),
                signingCredentials: signingCredentials
            );

            return token;
        }
    }
}
