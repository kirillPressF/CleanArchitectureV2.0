﻿using CleanArchitectureV2._0.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureV2._0.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<T>> GetAll (CancellationToken cancellationToken);
    }
}
