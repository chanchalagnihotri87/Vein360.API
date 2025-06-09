using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Persistence.Configurations
{
    public class DonorPreferenceConfiguration : IEntityTypeConfiguration<DonorPreference>
    {
        public void Configure(EntityTypeBuilder<DonorPreference> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Donor).WithMany().HasForeignKey(x => x.DonorId);

            builder.HasOne(x => x.Clinic).WithMany().HasForeignKey(x => x.DefaultClinicId);
        }
    }
}
