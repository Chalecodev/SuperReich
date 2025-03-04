﻿using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;
using static SuperReich.Application.Helper.Encryptor;

namespace SuperReich.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IAsyncRepository<User> repository, IDateTimeChile dateTimeChile) : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IAsyncRepository<User> _repository = repository;
        private readonly IDateTimeChile _dateTimeChile = dateTimeChile;

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Rut = new RUT(request.Rut).Value,
                Names = request.Names,
                Passport = request.Passport,
                Surnames = request.Surnames,
                Email = request.Email,
                Password = EncryptPassword(request.Password),
                PhoneNumber = request.PhoneNumber,
                Birthdate = _dateTimeChile.GetSpecificChileTime(request.Birthdate),
                Address = request.Address,
                RoleId = request.RoleId,
            };

            var response = await _repository.AddAsync(user);
            return response.UserId;
        }
    }
}
