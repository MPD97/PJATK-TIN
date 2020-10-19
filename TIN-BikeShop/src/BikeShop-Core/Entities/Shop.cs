using System;
using System.Collections.Generic;
using System.Reflection;

namespace BikeShop_Core.Entities
{
    public class Shop
    {
        public static readonly int NAME_MAX_LENGTH = 150;
        public static readonly int PHOTO_PATH_MAX_LENGTH = 260;

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

        public virtual ICollection<Storage> Storages { get; set; }
    }
}
