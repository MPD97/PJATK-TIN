using BikeShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop_Infrastructure.Configurations
{
    class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(a => a.LanguageId);

            builder.Property(a => a.LanguageLong)
                .HasMaxLength(Language.LANGUAGE_LONG_MAX_LENGTH)
                .IsRequired();

            builder.Property(a => a.LanguageShort)
                .HasMaxLength(Language.LANGUAGE_SHORT_MAX_LENGTH)
                .IsRequired();

            builder.HasMany(a => a.ProductDescriptions)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.ProductNames)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
