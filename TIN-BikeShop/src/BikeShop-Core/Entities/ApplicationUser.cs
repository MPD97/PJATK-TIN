using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop_Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {

    }
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name)
        {
            Name = name;
        }
    }
}

