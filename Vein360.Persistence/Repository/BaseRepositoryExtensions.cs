using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Persistence.Repository
{
    public static class BaseRepositoryExtensions
    {
        public static IQueryable<T> AddIncludes<T>(this IQueryable<T> query, Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] includes)
        {

            if (includes == null || !includes.Any())
            {
                return query;
            }

            foreach (var inlcude in includes)
            {
                var exp = inlcude.Compile();

                query = exp.Invoke(query);
            }

            return query;
        }
    }


}
