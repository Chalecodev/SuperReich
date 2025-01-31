using SuperReich.Application.DTOs.Auth.Login;
using SuperReich.Application.Features.Auth.Commands;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Contracts.Persistence
{
    public interface IAuthRepository
    {
        Task<LoginResponse>? Login(LoginCommand request);
        Task<User>? Register(User request);
    }
}
