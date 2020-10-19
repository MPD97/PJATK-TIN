using BikeShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop_Infrastructure.Configurations
{
    class ProductDescriptionTranslationConfiguration : IEntityTypeConfiguration<ProductDescriptionTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductDescriptionTranslation> builder)
        {
            builder.HasKey(a => new { a.ProductId, a.LanguageId });

            builder.Property(a => a.Text)
                .HasMaxLength(ProductDescriptionTranslation.TEXT_MAX_LENGTH)
                .IsRequired();

        }
    }
}
