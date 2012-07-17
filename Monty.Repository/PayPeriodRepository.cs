using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.DAL;

namespace Monty.Repository
{
    public class PayPeriodRepository : Monty.Repository.IPayPeriodRepository
    {
        private MongoCollection<BsonDocument> _payPeriods;
        private MongoDatabase _montyTestDb;


        public PayPeriodRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _payPeriods = _montyTestDb.GetCollection("payperiod");
        }


        public void ClearAllPayPeriods()
        {
            _montyTestDb.GetCollection("payperiod").Drop();
        }

        public virtual void AddNew(PayPeriod newPeriod)
        {
            _payPeriods.Insert(newPeriod);
        }

        public PayPeriod GetPayPeriodByName(string payPeriodName)
        {
            var query = new QueryDocument("PayPeriodName", payPeriodName);
            return _payPeriods.FindOneAs<PayPeriod>(query);

        }

        public IEnumerable<PayPeriod> GetAllPayPeriods()
        {
            return _payPeriods.FindAllAs<PayPeriod>();
        }

        public void Update(PayPeriod payPeriod)
        {
            _payPeriods.Save(payPeriod);
        }

        public PayPeriod GetPayPeriodById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _payPeriods.FindOneAs<PayPeriod>(query);
        }

        public void Delete(string name)
        {
            var query = new QueryDocument("PayPeriodName", name);
            _payPeriods.Remove(query);
        }


        public void DeleteById(string payPeriodId)
        {
            var query = new QueryDocument("_id", payPeriodId);
            _payPeriods.Remove(query);
        }
    }
}
