﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Contracts
{
    public interface IPersistenceContract
    {
        IDataSet<TEntity> Set<TEntity>(); 

        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }

    public interface IDataSet<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>
    {
        ValueTask<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task AddRange(params TEntity[] entities);

        IQueryable<TEntity> AsQueryable();

        ValueTask<TEntity> Find(object[] keyValues, CancellationToken cancellationToken);

        ValueTask<TEntity> Find(params object[] keyValues);

        TEntity Remove(TEntity entity);

        void RemoveRange(params TEntity[] entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        void UpdateRange(params TEntity[] entities);
        
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
