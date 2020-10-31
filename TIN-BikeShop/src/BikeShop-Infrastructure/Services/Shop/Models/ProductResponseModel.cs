namespace BikeShop_Infrastructure.Services.Shop.Models
{
    public class ProductResponseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public decimal Price { get; set; }

        public decimal PricePLN { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal PriceEUR { get; set; }

        public int Amount { get; set; }
    }
}
