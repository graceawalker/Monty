using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class CreditRepository : Monty.Repository.ICreditRepository
    {
        private MongoCollection<BsonDocument> _credits;
        private MongoDatabase _montyTestDb;


        public CreditRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _credits = _montyTestDb.GetCollection("credit");
        }


        public void ClearAllCredits()
        {
            _montyTestDb.GetCollection("credit").Drop();
        }

        public virtual void AddNew(Credit credit)
        {
            _credits.Insert(credit);
        }

        public Credit GetCreditByName(string creditName)
        {
            var query = new QueryDocument("Name", creditName);
            return _credits.FindOneAs<Credit>(query);

        }

        public virtual IEnumerable<Credit> GetAllCredits()
        {
            return _credits.FindAllAs<Credit>();
        }

        public void Update(Credit credit)
        {
            _credits.Save(credit);
        }

        public Credit GetCreditById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _credits.FindOneAs<Credit>(query);
        }

        public void Delete(string name)
        {
            var query = new QueryDocument("Name", name);
            _credits.Remove(query);
        }


        public void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _credits.Remove(query);
        }
    }
}
