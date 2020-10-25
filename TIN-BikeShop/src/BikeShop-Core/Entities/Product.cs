using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BikeShop_Core.Entities
{
    public class Product
    {
        public static readonly int PHOTO_PATH_MAX_LENGTH = 260;
        private string _photoPath;
        public int ProductId { get; set; }

        public virtual ICollection<ProductNameTranslation> ProductNames { get; set; }
        public virtual ICollection<ProductDescriptionTranslation> ProductDescriptions { get; set; }
        public string PhotoPath
        {
            get => _photoPath; set
            {
                if (value.Length > PHOTO_PATH_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {PHOTO_PATH_MAX_LENGTH} characters.");
                }
                else
                {
                    _photoPath = value;
                }
            }
        }
        public decimal PricePLN { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal PriceEUR { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }

    }
}
