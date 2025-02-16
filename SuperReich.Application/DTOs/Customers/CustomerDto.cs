using SuperReich.Domain.Common;

namespace SuperReich.Application.DTOs.Customers
{
    class CustomerDto: Audit
    {
        public int CustomerId { get; set; }
        public string? Rut { get; set; }
        public string? Passport { get; set; }
        public string? Names { get; set; } = string.Empty;
        public string? Surnames { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public bool BlackList { get; set; } = false;
    }
}
