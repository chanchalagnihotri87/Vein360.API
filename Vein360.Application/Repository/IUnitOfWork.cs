using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Repository
{
   public interface IUnitOfWork
    {
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
