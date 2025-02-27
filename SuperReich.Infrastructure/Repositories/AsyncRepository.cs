using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Infrastructure.Persistence;

namespace SuperReich.Infrastructure.Repositories
{
    public class AsyncRepository<T>(Context context) : IAsyncRepository<T> where T : class
    {
        private readonly Context _context = context;

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(predicate);
            return result ?? throw new KeyNotFoundException($"Entidad no encontrada con la condición especificada.");
        }

        public async Task<IReadOnlyList<T>> GetFilteredAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var response = await _context.Set<T>().ToListAsync();
            return response;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
