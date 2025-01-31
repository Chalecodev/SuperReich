using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Application.DTOs.Auth.Login;

namespace SuperReich.Application.Features.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthRepository _repository;
        public LoginCommandHandler(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Login(request);
        }
    }
}
