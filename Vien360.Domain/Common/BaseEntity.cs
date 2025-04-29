using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vien360.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.Now;
        public DateTimeOffset? UpdatedDate { get; set; } = null;
        public DateTimeOffset? DeletedDate { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

    }
}
