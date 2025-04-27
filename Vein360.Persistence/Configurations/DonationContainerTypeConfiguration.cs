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
    public class DonationContainerTypeConfiguration : IEntityTypeConfiguration<Vein360ContainerType>
    {
        public void Configure(EntityTypeBuilder<Vein360ContainerType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);


        }
    }
}
