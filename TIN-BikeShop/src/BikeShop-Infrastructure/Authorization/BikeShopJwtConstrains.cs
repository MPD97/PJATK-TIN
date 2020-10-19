using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Authorization
{
    public class BikeShopJwtConstrains
    {
        public const string Issuer = "BikeShop";
        public const string Audience = "ApplicationUser";
        public const string Key = "12345654323456";
    }
}
