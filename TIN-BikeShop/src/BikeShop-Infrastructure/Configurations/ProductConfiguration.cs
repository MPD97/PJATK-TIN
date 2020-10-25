using BikeShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop_Infrastructure.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.ProductId);

            builder.Property(a => a.PricePLN)
                .HasColumnType("decimal(10,2)");

            builder.Property(a => a.PriceUSD)
                .HasColumnType("decimal(10,2)");

            builder.Property(a => a.PriceEUR)
                .HasColumnType("decimal(10,2)");

            builder.Property(a => a.PhotoPath)
                .HasMaxLength(Product.PHOTO_PATH_MAX_LENGTH)
                .IsRequired();

            builder.HasMany(a => a.ProductNames)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.ProductDescriptions)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Storages)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
