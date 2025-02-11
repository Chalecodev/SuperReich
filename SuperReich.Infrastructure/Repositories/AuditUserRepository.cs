using SuperReich.Application.Contracts.Persistence;

namespace SuperReich.Infrastructure.Repositories
{
    internal class AuditUserRepository : IAuditUserRepository
    {
        public string GetCurrentUser(string rut)
        {
            return rut;
        }
    }
}
