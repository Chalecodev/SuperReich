using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Contracts.Persistence
{
    public interface IAuditUserRepository
    {
        string GetCurrentUser(string rut);
    }
}
