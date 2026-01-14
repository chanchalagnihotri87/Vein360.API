using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Persistence.Configurations
{
    public class PickupConfiguration : IEntityTypeConfiguration<Pickup>
    {
        public void Configure(EntityTypeBuilder<Pickup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PickupTransactionId).IsRequired();

            builder.Property(x => x.PickupConfirmationCode).IsRequired();

            builder.HasOne(x => x.Clinic).WithMany().HasForeignKey(x => x.ClinicId);
        }
    }
}
