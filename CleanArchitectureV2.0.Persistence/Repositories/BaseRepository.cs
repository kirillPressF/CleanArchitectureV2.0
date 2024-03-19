using CleanArchitectureV2._0.Application.Repositories;
using CleanArchitectureV2._0.Domain.Common;
using CleanArchitectureV2._0.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureV2._0.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            _context.Update(entity);
        }

        public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}