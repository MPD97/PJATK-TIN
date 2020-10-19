using BikeShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(new ApplicationRole { Id = 1, Name = "User", NormalizedName = "User".ToUpper() });
            builder.HasData(new ApplicationRole { Id = 2, Name = "Admin", NormalizedName = "Admin".ToUpper() });
            builder.HasData(new ApplicationRole { Id = 3, Name = "Moderator", NormalizedName = "Moderator".ToUpper() });
        }
    }
}
