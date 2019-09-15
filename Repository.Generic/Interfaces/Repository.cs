using Repository.Generic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace Repository.Generic
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly IDbContext DbContext;
        protected readonly DbSet<T> DbSet;
        protected readonly ILogger Logger;

        public Repository(IDbContext context, ILogger logger)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            DbSet = DbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                Logger.LogCritical($"{nameof(AddAsync)}: {nameof(Logger)} is null.");
                throw new ArgumentNullException(nameof(entity));
            }

            return (await DbSet.AddAsync(entity, cancellationToken)).Entity;
        }

        public async Task AddIfNotExistsAsync(T entity, Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            var exists = await DbSet.AnyAsync(predicate ?? throw new ArgumentNullException(nameof(predicate)), cancellationToken);

            if (!exists)
            {
                await DbSet.AddAsync(entity, cancellationToken);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null)
            {
                Logger.LogCritical($"{nameof(AddRangeAsync)}: The collection {nameof(entities)} is null.");
                throw new ArgumentNullException(nameof(entities));
            }

            await DbSet.AddRangeAsync(entities, cancellationToken);
        }

        public async Task AddRangeIfNotExistsAsync(IEnumerable<T> entities, Func<T, object> predicate, CancellationToken cancellationToken = default)
        {
            var exist = from ent in DbSet
                where entities.Any(e => predicate(ent).Equals(predicate(e)))
                select ent;

            await DbSet.AddRangeAsync(entities.Except(exist), cancellationToken);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
