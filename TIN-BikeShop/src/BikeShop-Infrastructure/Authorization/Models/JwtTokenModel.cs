using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Authorization.Models
{
    public class JwtTokenModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
