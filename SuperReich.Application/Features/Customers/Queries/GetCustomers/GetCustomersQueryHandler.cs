using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Customers;

namespace SuperReich.Application.Features.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryHandler(IAsyncRepository<Customer> repository) : IRequestHandler<GetCustomersQuery, IReadOnlyList<Customer>>
    {
        private readonly IAsyncRepository<Customer> _repository = repository;
        public async Task<IReadOnlyList<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllAsync();
            var customers = response.Select(customer => new Customer
            {
                CustomerId = customer.CustomerId,
                Rut = customer.Rut,
                Passport = customer.Passport,
                Names = customer.Names,
                Surnames = customer.Surnames,
                Email = customer.Email,
                Nationality = customer.Nationality,
                PhoneNumber = customer.PhoneNumber,
                Birthdate = customer.Birthdate,
                Address = customer.Address,
                Note = customer.Note,
                BlackList = customer.BlackList,
                CreatedBy = customer.CreatedBy,
                CreatedDate = customer.CreatedDate,
                LastModifiedBy = customer.LastModifiedBy,
                LastModifiedDate = customer.LastModifiedDate,
                IsActivated = customer.IsActivated
            }).ToList();

            return response;
        }
    }
}
