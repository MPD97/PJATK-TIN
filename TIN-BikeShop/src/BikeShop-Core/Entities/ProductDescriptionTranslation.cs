using System;
using System.Reflection;

namespace BikeShop_Core.Entities
{
    public class ProductDescriptionTranslation
    {
        public readonly int TEXT_MAX_LENGTH = 1000;
        private string _text;

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
}
