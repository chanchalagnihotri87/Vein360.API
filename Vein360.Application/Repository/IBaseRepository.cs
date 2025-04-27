using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Common;

namespace Vein360.Application.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<IQueryable<T>> GetAllAsQueryable();
        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<ICollection<T>> GetAllAsync(params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
        Task<ICollection<T>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken = default);
        Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes);
    }
}
