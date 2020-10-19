using BikeShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Configurations
{
    class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.AddressId);

            builder.Property(a => a.City)
                .HasMaxLength(Address.CITY_MAX_LENGTH)
                .IsRequired();

            builder.Property(a => a.Street)
                .HasMaxLength(Address.STREET_MAX_LENGTH)
                .IsRequired();

            builder.Property(a => a.StreetNumber)
                .HasMaxLength(Address.STREET_NUMBER_MAX_LENGTH)
                .IsRequired();

            builder.Property(a => a.ZipCode)
                .HasMaxLength(Address.ZIP_CODE_MAX_LENGTH)
                .IsRequired();

            builder.HasMany(a => a.Shops)
                .WithOne(a => a.Address)
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
