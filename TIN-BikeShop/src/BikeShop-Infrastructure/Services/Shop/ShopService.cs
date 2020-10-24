using BikeShop_Infrastructure.Contexts;
using BikeShop_Infrastructure.Services.Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop_Infrastructure.Services.Shop
{
    public class ShopService
    {
        private readonly BikeShopContext _context;

        public ShopService(BikeShopContext context)
        {
            _context = context;
        }

        public async Task<ShopResponseModel> Get(byte id)
        {
            var res = await _context.Shops
                .Where(shop => shop.ShopId == id)
                .Include(shop => shop.Address)
                .Select(shop => new ShopResponseModel
                {
                    ShopId = shop.ShopId,
                    Name = shop.Name,
                    PhotoPath = shop.PhotoPath,
                    City = shop.Address.City,
                    Street = shop.Address.Street,
                    StreetNumber = shop.Address.StreetNumber,
                    ZipCode = shop.Address.ZipCode
                }).FirstOrDefaultAsync();
            return res;
        }

        public async Task<ICollection<ShopResponseModel>> GetAll()
        {
            var res = await _context.Shops
                .Include(shop => shop.Address)
                .Select(shop => new ShopResponseModel
                {
                    ShopId = shop.ShopId,
                    Name = shop.Name,
                    PhotoPath = shop.PhotoPath,
                    City = shop.Address.City,
                    Street = shop.Address.Street,
                    StreetNumber = shop.Address.StreetNumber,
                    ZipCode = shop.Address.ZipCode
                }).ToArrayAsync();
            return res;
        }
    }
}
