using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BikeShop_Infrastructure.Authorization;
using BikeShop_Infrastructure.Contexts;
using BikeShop_Infrastructure.Services.Shop;
using BikeShop_Infrastructure.Services.Shop.Models;
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
        public async Task<IActionResult> GetAllProducts(byte shopId, [FromHeader] string language, [FromHeader] Currency currency)
        {
            return Ok(await _serivce.GetShopProducts(shopId, language, currency));
        }

        [HttpGet("{shopId}/Product/{productId}")]
        public async Task<IActionResult> GetProducts(byte shopId, int productId, [FromHeader] string language, [FromHeader] Currency currency)
        {
            return Ok(await _serivce.GetShopProduct(shopId, productId, language, currency));
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut("{shopId}/Product/{productId}")]
        public async Task<IActionResult> UpdateProduct(byte shopId, int productId, [FromHeader] string language, [FromForm] ProductPutModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid.");
            }
            if (await _serivce.PutShopProduct(shopId, productId, language, model))
            {
                return Ok();
            }
            return BadRequest("Something went wrong.");
        }
    }
}
