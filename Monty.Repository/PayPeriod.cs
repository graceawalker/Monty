using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace Monty.Repository
{
    public class PayPeriod
    {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

       [BsonDateTimeOptions]
        public DateTime StartDate { get; set; }

        [BsonDateTimeOptions]
        public DateTime EndDate { get; set; }
    }
}
