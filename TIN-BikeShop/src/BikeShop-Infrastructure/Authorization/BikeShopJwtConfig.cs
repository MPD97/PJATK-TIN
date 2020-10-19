using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Authorization
{
    public class BikeShopJwtConfig
    {
        public string Issuer { get; set; } 
        public string Audience { get; set; }
        public string Key { get; set; }

        public const string AuthShemes  = "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
