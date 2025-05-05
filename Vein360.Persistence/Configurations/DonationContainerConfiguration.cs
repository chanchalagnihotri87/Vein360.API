using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain;
using Vien360.Domain.Entities;

namespace Vein360.Persistence.Configurations
{
    public class DonationContainerConfiguration : IEntityTypeConfiguration<DonationContainer>
    {
        public void Configure(EntityTypeBuilder<DonationContainer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ContainerType).WithMany().HasForeignKey(x => x.ContainerTypeId);

            builder.HasOne(builder => builder.Container).WithMany().HasForeignKey(x => x.ContainerId);

            builder.Property(x => x.Status).HasConversion<int>();

            builder.HasOne(x => x.Donor).WithMany().HasForeignKey(x => x.DonorId);
        }
    }
}
