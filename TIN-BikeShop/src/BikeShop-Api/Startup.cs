using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop_Core.Entities;
using BikeShop_Infrastructure.Authorization;
using BikeShop_Infrastructure.Configurations.Seed;
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
using Microsoft.IdentityModel.Tokens;

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
            BikeShopJwtConfig jwtConfig = new BikeShopJwtConfig();
            _configuration.GetSection("BikeShopJwtConstrains").Bind(jwtConfig);

            services.AddSingleton<BikeShopJwtConfig>(jwtConfig);

            services.AddDbContext<BikeShopContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("default"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BikeShopContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddCookie(config =>
                {
                    config.SlidingExpiration = true;
                })
                .AddJwtBearer(config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtConfig.Issuer,
                        ValidAudience = jwtConfig.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
                    };
                });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, BikeShopContext context, UserManager<ApplicationUser> userManager)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (_environment.IsProduction())
            {
                context.Database.Migrate();
            }

            ApplicationUsersInitializer.SeedUsers(userManager);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
