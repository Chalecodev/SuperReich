using MediatR;
using SuperReich.Domain.Entities.Customers;

namespace SuperReich.Application.Features.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery: IRequest<IReadOnlyList<Customer>>;
}
