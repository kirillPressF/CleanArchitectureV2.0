using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureV2._0.Domain.Entities;

namespace CleanArchitectureV2._0.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
