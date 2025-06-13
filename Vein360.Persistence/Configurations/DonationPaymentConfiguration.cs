using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Persistence.Configurations
{
    public class DonationPaymentConfiguration : IEntityTypeConfiguration<DonationPayment>
    {
        public void Configure(EntityTypeBuilder<DonationPayment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Donation).WithMany().HasForeignKey(x => x.DonationId);
        }
    }
}
