using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vein360.Persistence.Configurations
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContainerType).HasConversion<int>();
            builder.Property(x => x.Status).HasConversion<int>();

            builder.HasOne(x => x.DonationContainer).WithMany().HasForeignKey(x => x.DonationContainerId);
            builder.HasOne(x => x.Donor).WithMany().HasForeignKey(x => x.DonorId);

            builder.HasMany(x => x.Products);

            builder.HasIndex(x => x.IsDeleted);
        }
    }
}
