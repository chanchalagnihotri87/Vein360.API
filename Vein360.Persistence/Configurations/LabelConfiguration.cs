using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Persistence.Configurations
{
    public class LabelConfiguration : IEntityTypeConfiguration<ShippingLabel>
    {
        public void Configure(EntityTypeBuilder<ShippingLabel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TrackingNumber).IsRequired();

            builder.HasIndex(x => x.TrackingNumber).IsUnique();

            builder.HasOne(x => x.Clinic).WithMany().HasForeignKey(x => x.ClinicId);

            builder.HasIndex(x => x.IsDeleted);
        }
    }
}
