using System;
using System.Reflection;

namespace BikeShop_Core.Entities
{
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
