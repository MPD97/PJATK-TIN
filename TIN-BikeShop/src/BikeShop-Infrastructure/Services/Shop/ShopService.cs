using BikeShop_Core.Entities;
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
    public interface IShopService
    {
        public Task<ShopResponseModel> Get(byte id);
        public Task<ICollection<ShopResponseModel>> GetAll();
        public Task<ICollection<ProductResponseModel>> GetAllProducts(byte shopId, byte languageId, Currency currency);

    }
    public class ShopService : IShopService
    {
        private readonly BikeShopContext _context;

        public ShopService(BikeShopContext context)
        {
            _context = context;
        }

        public async Task<ShopResponseModel> Get(byte id)
        {
            var res = await _context.Shops
                .AsNoTracking()
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
                .AsNoTracking()
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
        public async Task<ICollection<ProductResponseModel>> GetAllProducts(byte shopId, byte languageId, Currency currency)
        {
            var res = _context.Storages
                .AsNoTracking()
                .Where(storage => storage.ShopId == shopId)
                .Include(storage => storage.Product)
                    .ThenInclude(product => product.ProductNames)
                .Include(storage => storage.Product)
                    .ThenInclude(product => product.ProductDescriptions);

            switch (currency)
            {
                case Currency.PLN:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PricePLN,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == languageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == languageId).Text,
                            Amount = storage.Amount
                        }).ToArrayAsync();
                    }
                case Currency.USD:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PriceUSD,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == languageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == languageId).Text,
                            Amount = storage.Amount
                        }).ToArrayAsync();
                    }
                case Currency.EUR:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PriceEUR,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == languageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == languageId).Text,
                            Amount = storage.Amount
                        }).ToArrayAsync();
                    }
                default:
                    {
                        throw new NotImplementedException("Podano niezną walutę");
                    }
            }
        }

    }
    public enum Currency
    {
        PLN,
        USD,
        EUR
    }
}
