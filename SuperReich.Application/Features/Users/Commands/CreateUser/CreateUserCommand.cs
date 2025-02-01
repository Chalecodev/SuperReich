using MediatR;

namespace SuperReich.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Rut { get; set; } = string.Empty;
        public string Names { get; set; } = string.Empty;
        public string Surnames { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Address { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
