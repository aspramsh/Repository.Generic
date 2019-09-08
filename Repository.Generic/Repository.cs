using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Generic
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddIfNotExistsAsync(T entity, Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeIfNotExistsAsync(IEnumerable<T> entities, Func<T, object> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
