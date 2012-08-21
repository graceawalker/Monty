using MongoDB.Bson.Serialization;
using Monty.Model.DAL;

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
