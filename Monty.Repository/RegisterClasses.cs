using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization;

namespace Monty.Repository
{
    public static class RegisterClasses
    {
        public static void RegisterClassMaps()
        {
            BsonClassMap.RegisterClassMap<PayPeriod>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
