using BikeShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop_Infrastructure.Configurations
{
    class ProductNameTranslationConfiguration : IEntityTypeConfiguration<ProductNameTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductNameTranslation> builder)
        {
            builder.HasKey(a => new { a.ProductId, a.LanguageId });

            builder.Property(a => a.Text)
                .HasMaxLength(ProductNameTranslation.TEXT_MAX_LENGTH)
                .IsRequired();
        }
    }
}
