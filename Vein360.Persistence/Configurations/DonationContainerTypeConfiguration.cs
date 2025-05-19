using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
