using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop_Core.Entities;
using BikeShop_Infrastructure.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BikeShop_Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration ?? throw new NullReferenceException("IConfiguration is null.");
            _environment = environment ?? throw new NullReferenceException("IWebHostEnvironment is null.");
        }


        public void ConfigureServices(IServiceCollection services)
        {
            if (_environment.IsDevelopment())
            {
                services.AddDbContext<BikeShopContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName: "BikeShop");
                });
            }
            else if (_environment.IsProduction())
            {
                services.AddDbContext<BikeShopContext>(options =>
                {
                    options.UseSqlServer(_configuration.GetConnectionString("default"));
                });
            }
            else { throw new NotImplementedException(); }

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BikeShopContext>()
                .AddDefaultTokenProviders();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, BikeShopContext context)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (_environment.IsProduction())
            {
                context.Database.Migrate();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
