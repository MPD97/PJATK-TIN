using BikeShop_Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Contexts
{
    public class BikeShopContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDescriptionTranslation> ProductDescriptions { get; set; }
        public DbSet<ProductNameTranslation> ProductNames { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Storage> Storages { get; set; }

        public BikeShopContext(DbContextOptions options) : base(options)
        {
        }

        protected BikeShopContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



        }
    }

}
