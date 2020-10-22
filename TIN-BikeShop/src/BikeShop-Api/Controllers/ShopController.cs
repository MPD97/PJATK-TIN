using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop_Infrastructure.Authorization;
using BikeShop_Infrastructure.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop_Api.Controllers
{
    [Authorize(Roles = "Moderator")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly BikeShopContext _context;

        public ShopController(BikeShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new { example = "success" });
        }

    }
}
