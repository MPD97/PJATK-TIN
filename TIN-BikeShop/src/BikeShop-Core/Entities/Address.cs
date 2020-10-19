using System;
using System.Collections.Generic;
using System.Reflection;

namespace BikeShop_Core.Entities
{
    public class Address
    {
        public static readonly int CITY_MAX_LENGTH = 100;
        public static readonly int STREET_MAX_LENGTH = 150;
        public static readonly int STREET_NUMBER_MAX_LENGTH = 30;
        public static readonly int ZIP_CODE_MAX_LENGTH = 30;

        private string _city;
        private string _street;
        private string _streetNumber;
        private string _zipCode;

        public int AddressId { get; set; }

        public string City { get => _city; set
            {
                if (value.Length > CITY_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {CITY_MAX_LENGTH} characters.");
                }
                else
                {
                    _city = value;
                }
            }
        }
        public string Street { get => _street; set
            {
                if (value.Length > STREET_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {STREET_MAX_LENGTH} characters.");
                }
                else
                {
                    _street = value;
                }
            }
        }
        public string StreetNumber { get => _streetNumber; set
            {
                if (value.Length > STREET_NUMBER_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {STREET_NUMBER_MAX_LENGTH} characters.");
                }
                else
                {
                    _streetNumber = value;
                }
            }
        }
        public string ZipCode { get => _zipCode; set
            {
                if (value.Length > ZIP_CODE_MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} has maximum length of: {ZIP_CODE_MAX_LENGTH} characters.");
                }
                else
                {
                    _zipCode = value;
                }
            }
        }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
