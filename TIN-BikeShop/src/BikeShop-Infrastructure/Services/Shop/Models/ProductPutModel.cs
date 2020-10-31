using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeShop_Infrastructure.Services.Shop.Models
{
    public class ProductPutModel
    {
        [Required]
        [MinLength(10), MaxLength(1000)]
        public string Name { get; set; }

        [Required]
        [MinLength(10), MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999")]
        public decimal PricePLN { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999")]
        public string PriceEUR { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999")]
        public string PriceUSD { get; set; }
    }
}
