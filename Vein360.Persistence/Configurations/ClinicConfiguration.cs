using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Persistence.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClinicCode).IsRequired();

            builder.Property(x => x.ClinicName);

            builder.Property(x => x.StreetLine).IsRequired().HasMaxLength(35);

            builder.Property(x => x.City).IsRequired().HasMaxLength(35);

            builder.Property(x => x.State).HasMaxLength(2);

            builder.Property(x => x.Country).IsRequired().HasMaxLength(2);

            builder.Property(x => x.PostalCode).HasMaxLength(10);

            builder.Property(x => x.Phone).HasMaxLength(15);

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            builder.HasIndex(x => x.IsDeleted);
        }
    }
}
