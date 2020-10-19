using System.Collections.Generic;
using System.Text;

namespace BikeShop_Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public virtual ICollection<ProductNameTranslation> ProductNames { get; set; }
        public virtual ICollection<ProductDescriptionTranslation> ProductDescriptions { get; set; }

        public decimal PricePLN { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal PriceEUR { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }

    }
}
