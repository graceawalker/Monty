using MongoDB.Bson.Serialization;
using Monty.DAL;

namespace Monty.Repository
{
    public static class RegisterClasses
    {
        public static void RegisterClassMaps()
        {
            BsonClassMap.RegisterClassMap<AccountCredit>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
