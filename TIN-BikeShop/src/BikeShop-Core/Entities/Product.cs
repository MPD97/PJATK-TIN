using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Core.Entities
{
    public class Language
    {
        public byte LanguageId { get; set; }

        public string LanguageLong { get; set; }
        public string LanguageShort { get; set; }
    }
    public class ProductNameTranslation
    {
        public int TranslationId { get; set; }

        public string Text { get; set; }

        public byte LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class ProductDescriptionTranslation
    {
        public int TranslationId { get; set; }

        public string Text { get; set; }

        public byte LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }

        public virtual ICollection<ProductNameTranslation> ProductNames { get; set; }
        public virtual ICollection<ProductDescriptionTranslation> ProductDescriptions { get; set; }

        public decimal PricePLN { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal PriceEUR { get; set; }

    }
    public class Shop
    {
        public int ShopId { get; set; }
        public int MyProperty { get; set; }
    }
}
