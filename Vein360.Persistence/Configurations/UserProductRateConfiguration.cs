using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Persistence.Configurations
{
    public class UserProductRateConfiguration : IEntityTypeConfiguration<UserProductRate>
    {
        public void Configure(EntityTypeBuilder<UserProductRate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x=> x.User).WithMany().HasForeignKey(x=>x.UserId);

            builder.HasOne(x=> x.Product).WithMany().HasForeignKey(x=>x.ProductId);
        }
    }
}
