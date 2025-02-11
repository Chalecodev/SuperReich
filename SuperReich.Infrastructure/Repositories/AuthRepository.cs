using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Application.DTOs.Auth.Login;
using SuperReich.Application.Features.Auth.Commands;
using SuperReich.Domain.Entities.Users;
using SuperReich.Infrastructure.Persistence;
using SuperReich.Infrastructure.Services;
using static SuperReich.Infrastructure.Services.Encryptor;

namespace SuperReich.Infrastructure.Repositories
{
    public class AuthRepository(Context context, JwtTokenService jwtTokenService) : IAuthRepository
    {
        private readonly Context _context = context;
        private readonly JwtTokenService _jwtTokenService = jwtTokenService;

        public async Task<LoginResponse>? Login(LoginCommand request)
        {
            var user = await _context.Users.Where(u => u.Rut == request.Rut).AsNoTracking().FirstOrDefaultAsync();
            var roles = await _context.Users.Include(r => r.Roles).Where(u => u.RoleId == user!.RoleId).AsNoTracking().FirstOrDefaultAsync();
            user!.Roles = roles!.Roles;

            if (user == null || !VerifyPassword(request.Password!, user.Password!))
                throw new Exception("El usuario o la contraseña son incorrectos");

            var token = await _jwtTokenService.GenerateToken(user);

            var response = new LoginResponse
            {
                Rut = user.Rut,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return response;
        }

        public Task<User>? Register(User request)
        {
            throw new NotImplementedException();
        }
    }
}
