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
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.IsDeleted);

            builder.Property(x => x.ContainerType).HasConversion<int>();
            builder.Property(x => x.Status).HasConversion<int>();

            builder.HasOne(x => x.DonationContainer).WithMany()
                .HasForeignKey(x => x.DonationContainerId);

            builder.HasMany(x => x.Products);

            builder.HasOne(x => x.Donor).WithMany().HasForeignKey(x => x.DonorId);
        }
    }
}
