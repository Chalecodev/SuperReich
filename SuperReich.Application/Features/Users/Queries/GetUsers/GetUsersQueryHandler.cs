using AutoMapper;
using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Application.DTOs.Users;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler(IMapper mapper, IAsyncRepository<User> repository) : IRequestHandler<GetUsersQuery, IReadOnlyList<UserDto>>
    {
        private readonly IAsyncRepository<User> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IReadOnlyList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllAsync(includes: r => r.Roles!);
            var users = response.Select(user => new UserDto
            {
                UserId = user.UserId,
                Rut = user.Rut,
                Passport = user.Passport,
                Names = user.Names,
                Surnames = user.Surnames,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Birthdate = user.Birthdate,
                Address = user.Address,
                RoleName = user!.Roles != null ? user.Roles!.Rolename : string.Empty,
                CreatedBy = "Chaleco",
                LastModifiedBy = null,
                IsDeleted = false
            }).ToList();

            return _mapper.Map<IReadOnlyList<UserDto>>(users);
        }
    }
}
