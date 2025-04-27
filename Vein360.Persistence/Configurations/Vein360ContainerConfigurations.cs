using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Entities;

namespace Vein360.Persistence.Configurations
{
    public class Vein360ContainerConfigurations : IEntityTypeConfiguration<Vein360Container>
    {
        public void Configure(EntityTypeBuilder<Vein360Container> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ContainerType).WithMany().HasForeignKey(x => x.ContainerTypeId);

            builder.Property(x => x.Status).HasConversion<int>();

            builder.HasIndex(x => x.IsDeleted);
        }
    }
}
