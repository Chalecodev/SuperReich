using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Customers;

namespace SuperReich.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler(IAsyncRepository<Customer> repository) : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IAsyncRepository<Customer> _repository = repository;

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Rut = request.Rut,
                Passport = request.Passport,
                Names = request.Names,
                Surnames = request.Surnames,
                Email = request.Email,
                Nationality = request.Nationality,
                PhoneNumber = request.PhoneNumber,
                Birthdate = request.Birthdate,
                Address = request.Address,
                Note = request.Note,
                BlackList = request.BlackList,
            };
            var result = await _repository.AddAsync(customer);
            return result.CustomerId;
        }
    }
}
