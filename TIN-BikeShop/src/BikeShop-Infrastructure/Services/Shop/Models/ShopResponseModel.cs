using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Services.Shop.Models
{
    public class ShopResponseModel
    {
        public byte ShopId { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
    }
}
