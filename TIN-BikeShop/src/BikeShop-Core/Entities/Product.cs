using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BikeShop_Core.Entities
{
    public class Language
    {
        public readonly int LANGUAGE_LONG_MAX_LENGTH = 100;
        public readonly int LANGUAGE_SHORT_MAX_LENGTH = 3;
        private string _languageLong;
        private string _languageShort;

        public byte LanguageId { get; set; }

        public string LanguageLong { get => _languageLong; set
            {
                if (value.Length > LANGUAGE_LONG_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {LANGUAGE_LONG_MAX_LENGTH} characters.");
                }
                else
                {
                    _languageLong = value;
                }
            }
        }
        public string LanguageShort { get => _languageShort; set
            {
                if (value.Length > LANGUAGE_SHORT_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {LANGUAGE_SHORT_MAX_LENGTH} characters.");
                }
                else
                {
                    _languageShort = value;
                }
            }
        }
    }
    public class ProductNameTranslation
    {
        public readonly int TEXT_MAX_LENGTH = 1000;
        private  string _text;

        public int TranslationId { get; set; }

        public string Text { get => _text; set
            {
                if (value.Length > TEXT_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {TEXT_MAX_LENGTH} characters.");
                }
                else
                {
                    _text = value;
                }
            }
        }

        public byte LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class ProductDescriptionTranslation
    {
        public readonly int TEXT_MAX_LENGTH = 1000;
        private string _text;

        public int TranslationId { get; set; }

        public string Text
        {
            get => _text; set
            {
                if (value.Length > TEXT_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {TEXT_MAX_LENGTH} characters.");
                }
                else
                {
                    _text = value;
                }
            }
        }


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
