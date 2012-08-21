using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class DebitRepository : IDebitRepository
    {
        private MongoCollection<BsonDocument> _debits;
        private MongoDatabase _montyTestDb;


        public DebitRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _debits = _montyTestDb.GetCollection("debit");
        }


        public void ClearAllDebits()
        {
            _montyTestDb.GetCollection("debit").Drop();
        }

        public virtual void AddNew(Debit credit)
        {
            _debits.Insert(credit);
        }

        public Debit GetDebitByName(string debitName)
        {
            var query = new QueryDocument("Name", debitName);
            return _debits.FindOneAs<Debit>(query);

        }

        public virtual IEnumerable<Debit> GetAllDebits()
        {
            return _debits.FindAllAs<Debit>();
        }

        public void Update(Debit credit)
        {
            _debits.Save(credit);
        }

        public Debit GetDebitById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _debits.FindOneAs<Debit>(query);
        }

        public void Delete(string name)
        {
            var query = new QueryDocument("Name", name);
            _debits.Remove(query);
        }


        public void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _debits.Remove(query);
        }
    }
}
