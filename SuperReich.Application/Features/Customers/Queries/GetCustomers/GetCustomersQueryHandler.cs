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
            return response;
        }
    }
}
