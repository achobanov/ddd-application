using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Gateways.Persistence
{
    public class DataSet<TEntity> : IDataSet<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;
        private readonly IQueryable<TEntity> queryable;

        public DataSet(DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
            this.queryable = dbSet.AsQueryable();
        }

        #region IQueryable implementaion

        public Type ElementType => this.queryable.ElementType;

        public Expression Expression => this.queryable.Expression;

        public IQueryProvider Provider => this.queryable.Provider;

        public IEnumerator<TEntity> GetEnumerator()
            => this.queryable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.queryable.GetEnumerator();

        #endregion

        #region IDataSet implementation

        public async ValueTask<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = await this.dbSet.AddAsync(entity, cancellationToken);

            return entry.Entity;
        }

        public Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => this.dbSet.AddRangeAsync(entities, cancellationToken);

        public Task AddRange(params TEntity[] entities)
            => this.dbSet.AddRangeAsync(entities);

        public IQueryable<TEntity> AsQueryable()
            => this.queryable;

        public ValueTask<TEntity> Find(object[] keyValues, CancellationToken cancellationToken)
            => this.dbSet.FindAsync(keyValues, cancellationToken);

        public ValueTask<TEntity> Find(params object[] keyValues)
            => this.dbSet.FindAsync(keyValues);

        public TEntity Remove(TEntity entity)
        {
            var entry = this.dbSet.Remove(entity);

            return entry.Entity;
        }

        public void RemoveRange(params TEntity[] entities)
            => this.dbSet.RemoveRange(entities);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => this.dbSet.RemoveRange(entities);

        public TEntity Update(TEntity entity)
        {
            var entry = this.dbSet.Update(entity);

            return entry.Entity;
        }

        public void UpdateRange(params TEntity[] entities)
            => this.dbSet.UpdateRange(entities);

        public void UpdateRange(IEnumerable<TEntity> entities)
            => this.dbSet.UpdateRange(entities);

        #endregion
    }
}
