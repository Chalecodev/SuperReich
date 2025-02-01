using SuperReich.Domain.Common;

namespace SuperReich.Application.DTOs.Users
{
    public class UserDto: Audit
    {
        public int UserId { get; set; }
        public string Rut { get; set; } = string.Empty;
        public string Names { get; set; } = string.Empty;
        public string Surnames { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
