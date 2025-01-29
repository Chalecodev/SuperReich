using System.Collections.Generic;

namespace SuperReich.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetBy(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
