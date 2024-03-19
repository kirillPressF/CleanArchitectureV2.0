using CleanArchitectureV2._0.Application.Repositories;
using CleanArchitectureV2._0.Domain.Entities;
using CleanArchitectureV2._0.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureV2._0.Persistence.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public async Task<UserEntity> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
