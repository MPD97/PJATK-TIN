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

        public string LanguageLong
        {
            get => _languageLong; set
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
        public string LanguageShort
        {
            get => _languageShort; set
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
        public readonly int NAME_MAX_LENGTH = 150;
        public readonly int PHOTO_PATH_MAX_LENGTH = 260;

        private string _name;
        private string _photoPath;

        public byte ShopId { get; set; }
        public string Name
        {
            get => _name; set
            {
                if (value.Length > NAME_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {NAME_MAX_LENGTH} characters.");
                }
                else
                {
                    _name = value;
                }
            }
        }
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

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public int AddressId { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Shop> ShopAddresses { get; set; }
    }
    public class Storage
    {
        public readonly int AMOUNT_MINIMUM_VALUE = 0;
        private int _amount;

        public int StorageId { get; set; }
        public int Amount
        {
            get => _amount; set
            {
                if (value < AMOUNT_MINIMUM_VALUE || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} cannot be lower than {AMOUNT_MINIMUM_VALUE} and bigger than {int.MaxValue}.");
                }
                else
                {
                    _amount = value;
                }
            }
        }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public byte ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
