using MediatR;
using SuperReich.Application.DTOs.Users;

namespace SuperReich.Application.Features.Users.Queries.GetAllUsers
{
    public class GetUsersQuery : IRequest<IReadOnlyList<UserDto>>;
}
