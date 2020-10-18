using BikeShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop_Infrastructure.Configurations
{
    class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(a => a.ShopId);

            builder.Property(a => a.Name)
                .HasMaxLength(Shop.NAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(a => a.PhotoPath)
                .HasMaxLength(Shop.PHOTO_PATH_MAX_LENGTH)
                .IsRequired();

            builder.HasMany(a => a.Storages)
                .WithOne(a => a.Shop)
                .HasForeignKey(a => a.ShopId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
