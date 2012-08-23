using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class CreditRepository : IRepository<Credit>
    {
        private MongoCollection<BsonDocument> _credits;
        private MongoDatabase _montyTestDb;


        public CreditRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _credits = _montyTestDb.GetCollection("credit");
        }


        public void AddNew(Credit entity)
        {
            _credits.Insert(entity);
        }

        public void ClearAll()
        {
            _montyTestDb.GetCollection("credit").Drop();
        }

        public Credit GetByName(string name)
        {
            var query = new QueryDocument("Name", name);
            return _credits.FindOneAs<Credit>(query);
        }

        public virtual IEnumerable<Credit> GetAll()
        {
            return _credits.FindAllAs<Credit>();
        }

        public void Update(Credit credit)
        {
            _credits.Save(credit);
        }

        public Credit GetById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _credits.FindOneAs<Credit>(query);
        }

        public void DeleteBy(string name)
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
