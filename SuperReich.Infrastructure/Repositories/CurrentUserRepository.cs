using Microsoft.AspNetCore.Http;
using SuperReich.Application.Contracts.Persistence;

namespace SuperReich.Infrastructure.Repositories
{
    public class CurrentUserRepository(IHttpContextAccessor httpContextAccessor) : ICurrentUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public string? Username => _httpContextAccessor.HttpContext?.User?.FindFirst("Username")?.Value;
    }
}
