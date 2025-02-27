using System.IdentityModel.Tokens.Jwt;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Contracts.Persistence
{
    public interface IJwtHandlerRepository
    {
        JwtSecurityToken GenerateToken(User user);
    }
}
