using MediatR;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Features.Users.Queries
{
    public class GetUsersQuery: IRequest<IReadOnlyList<User>>;
}
