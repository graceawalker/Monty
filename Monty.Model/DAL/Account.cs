using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;


namespace Monty.Model.DAL
{
    public class Account
    {
        public Account()
        {
            Debits = new List<Debit>();
            Credits = new List<Credit>();
        }

        public Account(string name):this()
        {
            Name = name;
        }

        [BsonElement]
        public string Name { get; set; }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public List<Credit> Credits { get; set; }
        public List<Debit> Debits { get; set; }
    }
}
