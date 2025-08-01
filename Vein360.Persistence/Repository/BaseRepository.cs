using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Vein360.Application.Repository;
using Vein360.Domain.Common;

namespace Vein360.Persistence.Repository
{
    public class BaseRepository<T>(Vein360Context context) : IBaseRepository<T> where T : BaseEntity
    {
        private readonly Vein360Context context = context;

        public void Create(T entity)
        {
            context.Add(entity);
        }

        public void CreateMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                context.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;

            context.Update(entity);

        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            Delete(entity);
        }

        public void DeleteMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;

                context.Update(entity);
            }
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().FindAsync([id], cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AddIncludes(includes).Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {

            return await context.Set<T>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AddIncludes(includes).Where(x => !x.IsDeleted).FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AsNoTracking().AddIncludes(includes).Where(x => !x.IsDeleted).FirstOrDefaultAsync(predicate);
        }


        public IQueryable<T> GetAllAsQueryable()
        {
            return context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }

        public async Task<ICollection<T>> GetAllAsync(params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AddIncludes(includes).Where(x => !x.IsDeleted).ToHashSetAsync();
        }

        public async Task<ICollection<T>> GetAllAsNoTrackingAsync(params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AsNoTracking().AddIncludes(includes).Where(x => !x.IsDeleted).ToHashSetAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AddIncludes(includes).Where(x => !x.IsDeleted).ToHashSetAsync(cancellationToken);
        }

        public ICollection<TResult> GetAllAsync<TResult>(Func<T, TResult> selector, CancellationToken cancellationToken)
        {
            return context.Set<T>().Where(x => !x.IsDeleted).AsQueryable().Select(selector).ToHashSet();
        }

        public async Task<ICollection<T>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().ToHashSetAsync(cancellationToken);
        }

        public ICollection<TResult> GetManyAsNoTracking<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> selector, CancellationToken cancellationToken = default)
        {
            return context.Set<T>().AsNoTracking().Where(x => !x.IsDeleted).Where(predicate).AsQueryable().Select(selector).ToHashSet();
        }

        public async Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().Where(x => !x.IsDeleted).Where(predicate).ToHashSetAsync(cancellationToken);
        }
        public async Task<ICollection<T>> GetManyAsNoTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().AsNoTracking().Where(x => !x.IsDeleted).Where(predicate).ToHashSetAsync(cancellationToken);
        }

        public async Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AddIncludes(includes).Where(x => !x.IsDeleted).Where(predicate).ToHashSetAsync(cancellationToken);
        }

        public async Task<ICollection<T>> GetManyAsNoTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {
            return await context.Set<T>().AsNoTracking().AddIncludes(includes).Where(x => !x.IsDeleted).Where(predicate).ToHashSetAsync(cancellationToken);
        }



        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            context.Update(entity);
        }

        public Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AnyAsync(predicate);
        }
    }
}
