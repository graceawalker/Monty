using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Monty.Repository
{
    public class PayPeriod
    {
        public PayPeriod(string name, string startDate, string endDate)
        {
            Name = name;
            DateTime parsed;
            DateTime.TryParse(startDate, out parsed);
            StartDate = parsed;
            DateTime.TryParse(endDate, out parsed);
            EndDate = parsed;

        }

        [BsonDateTimeOptions]
        public DateTime EndDate { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonDateTimeOptions]
        public DateTime StartDate { get; set; }
    }
}
