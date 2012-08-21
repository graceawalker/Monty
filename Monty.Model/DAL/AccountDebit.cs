using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;


namespace Monty.Model.DAL
{
    public class AccountDebit
    {
        public AccountDebit()
        {

        }

        public AccountDebit(string name, string date)
        {
            Name = name;
            DateTime parsed;
            DateTime.TryParse(date, out parsed);
            Date = parsed;
        }

        [BsonElement]
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

   

    }
}
