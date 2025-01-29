using Microsoft.EntityFrameworkCore;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Infrastructure.Persistence;

namespace SuperReich.Infrastructure.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly Context _context;
        public AsyncRepository(Context context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task<T> GetBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
