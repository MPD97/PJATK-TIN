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
        public BikeShopContext(DbContextOptions options) : base(options)
        {
        }

        protected BikeShopContext()
        {
        }
    }

}
