using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;

namespace Vein360.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Vein360Context context;

        public UnitOfWork(Vein360Context context)
        {
            this.context = context;
        }
        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
