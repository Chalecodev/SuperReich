using AutoMapper;
using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Application.DTOs.Users;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Features.Users.Queries.GetAllUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IReadOnlyList<UserDto>>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IMapper mapper, IAsyncRepository<User> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<UserDto>>(users);
        }
    }
}
