using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace BikeShop_Core.Entities
{
    public class Language
    {
        public static readonly int LANGUAGE_LONG_MAX_LENGTH = 100;
        public static readonly int LANGUAGE_SHORT_MAX_LENGTH = 3;
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
        public virtual ICollection<ProductDescriptionTranslation> ProductDescriptions { get; set; }
        public virtual ICollection<ProductNameTranslation> ProductNames { get; set; }
    }
}
