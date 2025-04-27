using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain;
using Vien360.Domain.Entities;

namespace Vein360.Persistence.Configurations
{
  public  class DonationProductConfiguration:IEntityTypeConfiguration<DonationProduct>
    {
        public void Configure(EntityTypeBuilder<DonationProduct> builder)
        {
            builder.HasKey(dp => dp.Id);
            builder.HasOne(x => x.Donation).WithMany(x => x.Products)
                .HasForeignKey(x => x.DonationId);

            builder.HasOne(x => x.Product).WithMany()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
