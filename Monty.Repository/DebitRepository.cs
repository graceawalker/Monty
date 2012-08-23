using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class DebitRepository : IRepository<Debit>
    {
        private MongoCollection<BsonDocument> _debits;
        private MongoDatabase _montyTestDb;


        public DebitRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _debits = _montyTestDb.GetCollection("debit");
        }


        public virtual void AddNew(Debit credit)
        {
            _debits.Insert(credit);
        }

        public void ClearAll()
        {
            _montyTestDb.GetCollection("debit").Drop();
        }

        public void DeleteBy(string name)
        {
            var query = new QueryDocument("Name", name);
            _debits.Remove(query);
        }

        public virtual IEnumerable<Debit> GetAll()
        {
            return _debits.FindAllAs<Debit>();
        }

        public Debit GetByName(string name)
        {
            var query = new QueryDocument("Name", name);
            return _debits.FindOneAs<Debit>(query);
        }

        public void Update(Debit credit)
        {
            _debits.Save(credit);
        }

        public Debit GetById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _debits.FindOneAs<Debit>(query);
        }

        public void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _debits.Remove(query);
        }
    }
}
