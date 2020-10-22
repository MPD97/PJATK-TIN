using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop_Core.Entities;
using BikeShop_Infrastructure.Authorization;
using BikeShop_Infrastructure.Configurations.Seed;
using BikeShop_Infrastructure.Contexts;
using BikeShop_Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            UserAuthorizationSettings authorizationSettings = new UserAuthorizationSettings();
            _configuration.GetSection("UserAuthorizationSettings").Bind(authorizationSettings);
            services.AddSingleton(authorizationSettings);

            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

            services.AddDbContext<BikeShopContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("default"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BikeShopContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                var key = Encoding.ASCII.GetBytes(authorizationSettings.Secret);

                config.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserAuthenticationService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
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

            context.Database.Migrate();

            ApplicationUsersInitializer.SeedUsers(userManager);

            app.UseCors(config => config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
