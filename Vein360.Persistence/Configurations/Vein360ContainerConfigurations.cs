using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vein360.Persistence.Configurations
{
    public class Vein360ContainerConfigurations : IEntityTypeConfiguration<Vein360Container>
    {
        public void Configure(EntityTypeBuilder<Vein360Container> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).HasConversion<int>();

            builder.HasOne(x => x.ContainerType).WithMany().HasForeignKey(x => x.ContainerTypeId);

            builder.HasIndex(x => x.IsDeleted);
        }
    }
}
