﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BikeShop_Infrastructure.Services
{
    public class UserAuthorizationSettings
    {
        private long _expireAfterMinutes;
        private string _secret;

        public long ExpireAfterMinutes
        {
            get => _expireAfterMinutes; set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} cannot be less or equal than 0!");
                }
                else
                {
                    _expireAfterMinutes = value;
                }
            }
        }
        public string Secret { get => _secret; set
            {
                if (value.Length != 13)
                {
                    throw new ArgumentOutOfRangeException($"Parameter: {MethodBase.GetCurrentMethod().Name} must be 13 characters long.");
                }
                else
                {
                    _secret = value;
                }
            }
        }
    }
}
