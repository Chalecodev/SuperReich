using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;

namespace SuperReich.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IAsyncRepository<User> repository, IDateTimeChile dateTimeChile) : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IAsyncRepository<User> _repository = repository;
        private readonly IDateTimeChile _dateTimeChile = dateTimeChile;

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updatedUser = await _repository.GetByIdAsync(u => u.UserId == request.UserId);

            updatedUser.Rut = !string.IsNullOrEmpty(request.Rut) ? new RUT(request.Rut).Value : new RUT(updatedUser.Rut).Value;
            updatedUser.Passport = request.Passport ?? updatedUser.Passport;
            updatedUser.Names = request.Names ?? updatedUser.Names;
            updatedUser.Surnames = request.Surnames ?? updatedUser.Surnames;
            updatedUser.Email = request.Email ?? updatedUser.Email;
            updatedUser.PhoneNumber = request.PhoneNumber ?? updatedUser.PhoneNumber;
            updatedUser.Birthdate = request.Birthdate != null ? _dateTimeChile.GetSpecificChileTime(request.Birthdate) : updatedUser.Birthdate;
            updatedUser.Address = request.Address ?? updatedUser.Address;
            updatedUser.RoleId = request.RoleId != null ? request.RoleId : updatedUser.RoleId;
            updatedUser.IsDeleted = request.IsDeleted;

            await _repository.UpdateAsync(updatedUser);

            return request.UserId;
        }
    }
}
