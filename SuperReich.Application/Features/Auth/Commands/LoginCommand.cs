using MediatR;
using SuperReich.Application.DTOs.Auth.Login;

namespace SuperReich.Application.Features.Auth.Commands
{
    public class LoginCommand: IRequest<LoginResponse>
    {
        public string Rut { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
