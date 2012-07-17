using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;


namespace Monty.DAL
{
    public class PayPeriod
    {
        public PayPeriod()
        {

        }
        public PayPeriod(string name, string startDate, string endDate)
        {
            PayPeriodName = name;
            DateTime parsed;
            DateTime.TryParse(startDate, out parsed);
            StartDate = parsed;
            DateTime.TryParse(endDate, out parsed);
            EndDate = parsed;

        }


        [BsonElement]
        public string PayPeriodName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

   

    }
}
