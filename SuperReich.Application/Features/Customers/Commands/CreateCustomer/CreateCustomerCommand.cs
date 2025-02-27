using MediatR;

namespace SuperReich.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand: IRequest<int>
    {
        public string? Rut { get; set; }
        public string? Passport { get; set; }
        public string Names { get; set; } = string.Empty;
        public string Surnames { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public bool BlackList { get; set; } = false;
    }
}
