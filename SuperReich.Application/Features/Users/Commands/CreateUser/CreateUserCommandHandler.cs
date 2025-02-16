using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;

namespace SuperReich.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IAsyncRepository<User> repository, IDateTimeChile dateTimeChile) : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IAsyncRepository<User> _repository = repository;
        private readonly IDateTimeChile _dateTimeChile = dateTimeChile;

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //DateTime.Parse("09-11-2001")
            //_dateTimeChile.GetSpecificChileTime(new DateTime(2001, 11, 09)), // YYYY/MM/DD
            var user = new User
            {
                Rut = new RUT(request.Rut).Value,
                Names = request.Names,
                Passport = request.Passport,
                Surnames = request.Surnames,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Birthdate = _dateTimeChile.GetSpecificChileTime(request.Birthdate),
                Address = request.Address,
                RoleId = request.RoleId,
                CreatedBy = "Chaleco",
                LastModifiedBy = null,
                IsDeleted = request.IsDeleted
            };

            var response = await _repository.AddAsync(user);
            return response.UserId;
        }
    }
}
