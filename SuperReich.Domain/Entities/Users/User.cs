using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.Roles;

namespace SuperReich.Domain.Entities.Users
{
    public class User : Audit
    {
        [Key]
        public int UserId { get; set; }
        public string Rut { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public string Names { get; set; } = string.Empty;
        public string Surnames { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Address { get; set; } = string.Empty;

        public int? RoleId { get; set; }
        public Role? Roles { get; set; }
    }
}
