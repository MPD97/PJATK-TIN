using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop_Infrastructure.Authorization;
using BikeShop_Infrastructure.Contexts;
using BikeShop_Infrastructure.Services.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _serivce;

        public ShopController(IShopService serivce)
        {
            _serivce = serivce;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(byte id)
        {
            return Ok(await _serivce.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _serivce.GetAll());
        }

        [HttpGet("{shopId}/Product")]
        public async Task<IActionResult> GetAllProducts(byte shopId, [FromHeader] string language, [FromHeader] Currency currency = Currency.PLN)
        {
            return Ok(await _serivce.GetAllProducts(shopId, language, currency));
        }
    }
}
