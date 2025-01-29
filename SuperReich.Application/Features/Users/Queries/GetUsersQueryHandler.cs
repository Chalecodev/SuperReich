using AutoMapper;
using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Features.Users.Queries
{
    public class GetUsersQueryHandler: IRequestHandler<GetUsersQuery, IReadOnlyList<User>>
    {
        private readonly IAsyncRepository<User> _asyncRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IMapper mapper, IAsyncRepository<User> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _asyncRepository.GetAllAsync();
            return users;
        }
    }
}
