using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vein360.Persistence.Configurations
{
    public class Vein360UserConfiguration : IEntityTypeConfiguration<Vein360User>
    {
        public void Configure(EntityTypeBuilder<Vein360User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password).IsRequired();

            builder.HasIndex(x => x.IsDeleted);
        }
    }
}
