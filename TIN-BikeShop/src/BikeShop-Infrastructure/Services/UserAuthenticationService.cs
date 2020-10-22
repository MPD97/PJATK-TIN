using BikeShop_Core.Entities;
using BikeShop_Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Services
{
    public class UserAuthenticationService
    {
        private readonly BikeShopContext _context;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly UserAuthorizationSettings _settings;

        public UserAuthenticationService(BikeShopContext context, IHttpContextAccessor httpAccessor, UserAuthorizationSettings settings)
        {
            _context = context;
            _httpAccessor = httpAccessor;
            _settings = settings;
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            throw new NotImplementedException(); 
        }



    }
}
