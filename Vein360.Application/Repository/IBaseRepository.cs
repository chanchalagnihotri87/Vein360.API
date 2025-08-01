using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Vein360.Domain.Common;

namespace Vein360.Application.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void CreateMany(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
        void DeleteMany(IEnumerable<T> entities);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        IQueryable<T> GetAllAsQueryable();
        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<ICollection<T>> GetAllAsync(params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<ICollection<T>> GetAllAsNoTrackingAsync(params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        ICollection<TResult> GetAllAsync<TResult>(Func<T, TResult> selector, CancellationToken cancellationToken);
        Task<ICollection<T>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken = default);
        ICollection<TResult> GetManyAsNoTracking<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> selector, CancellationToken cancellationToken = default);
        Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<ICollection<T>> GetManyAsNoTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<ICollection<T>> GetManyAsNoTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
    }
}
