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
        public Task<ICollection<ProductResponseModel>> GetShopProducts(byte shopId, string language, Currency currency);
        public Task<ProductResponseModel> GetShopProduct(byte shopId, int productId, string language, Currency currency);
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
        public async Task<ICollection<ProductResponseModel>> GetShopProducts(byte shopId, string language, Currency currency)
        {
            var lang = _context.Languages
                .AsNoTracking()
                .First(lang => lang.LanguageShort.ToUpper() == language.ToUpper());

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
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == lang.LanguageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == lang.LanguageId).Text,
                            Amount = storage.Amount,
                            PhotoPath = storage.Product.PhotoPath
                        }).ToArrayAsync();
                    }
                case Currency.USD:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PriceUSD,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == lang.LanguageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == lang.LanguageId).Text,
                            Amount = storage.Amount,
                            PhotoPath = storage.Product.PhotoPath
                        }).ToArrayAsync();
                    }
                case Currency.EUR:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PriceEUR,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == lang.LanguageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == lang.LanguageId).Text,
                            Amount = storage.Amount,
                            PhotoPath = storage.Product.PhotoPath
                        }).ToArrayAsync();
                    }
                default:
                    {
                        throw new NotImplementedException("Podano niezną walutę");
                    }
            }
        }
        public async Task<ProductResponseModel> GetShopProduct(byte shopId, int productId, string language, Currency currency)
        {
            var lang = _context.Languages
                .AsNoTracking()
                .First(lang => lang.LanguageShort.ToUpper() == language.ToUpper());

            var res = _context.Storages
                .AsNoTracking()
                .Where(storage => storage.ShopId == shopId)
                .Include(storage => storage.Product)
                    .ThenInclude(product => product.ProductNames)
                .Include(storage => storage.Product)
                    .ThenInclude(product => product.ProductDescriptions)
                    .Where(storage => storage.ProductId == productId);

            switch (currency)
            {
                case Currency.PLN:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PricePLN,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == lang.LanguageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == lang.LanguageId).Text,
                            Amount = storage.Amount,
                            PhotoPath = storage.Product.PhotoPath
                        }).FirstOrDefaultAsync();
                    }
                case Currency.USD:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PriceUSD,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == lang.LanguageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == lang.LanguageId).Text,
                            Amount = storage.Amount,
                            PhotoPath = storage.Product.PhotoPath
                        }).FirstOrDefaultAsync();
                    }
                case Currency.EUR:
                    {
                        return await res.Select(storage => new ProductResponseModel
                        {
                            ProductId = storage.Product.ProductId,
                            Price = storage.Product.PriceEUR,
                            Name = storage.Product.ProductNames.First(name => name.LanguageId == lang.LanguageId).Text,
                            Description = storage.Product.ProductDescriptions.First(name => name.LanguageId == lang.LanguageId).Text,
                            Amount = storage.Amount,
                            PhotoPath = storage.Product.PhotoPath
                        }).FirstOrDefaultAsync();
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
