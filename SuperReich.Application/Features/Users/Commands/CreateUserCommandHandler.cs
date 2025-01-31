using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;

namespace SuperReich.Application.Features.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IDateTimeChile _dateTimeChile;
        public CreateUserCommandHandler(IAsyncRepository<User> repository, IDateTimeChile dateTimeChile)
        {
            _repository = repository;
            _dateTimeChile = dateTimeChile;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //DateTime.Parse("09-11-2001")
            //_dateTimeChile.GetSpecificChileTime(new DateTime(2001, 11, 09)), // YYYY/MM/DD
            var user = new User
            {
                Rut = new RUT(request.Rut).Value,
                Names = request.Names,
                Surnames = request.Surnames,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Birthdate = _dateTimeChile.GetSpecificChileTime(request.Birthdate),
                Address = request.Address,
                RoleId = request.RoleId,
                CreatedBy = "Chaleco",
                CreatedDate = _dateTimeChile.GetCurrentChileTime(),
                LastModifiedBy = null,
                LastModifiedDate = null,
                IsDeleted = false
            };

            var result = await _repository.AddAsync(user);
            return result.Id;
        }
    }
}
