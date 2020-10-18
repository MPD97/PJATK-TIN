using System.Collections.Generic;

namespace BikeShop_Core.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Shop> ShopAddresses { get; set; }
    }
}
