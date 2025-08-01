using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vein360.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Vein360ProductId).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Image).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Type).HasConversion<int>();
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p=> p.Trade).HasDefaultValue(TradeType.Sort).HasConversion<int>();
            builder.HasIndex(x => x.Trade);
            builder.HasIndex(x => x.IsDeleted);

            builder.HasIndex(x => x.Vein360ProductId).IsUnique();
        }
    }
}
