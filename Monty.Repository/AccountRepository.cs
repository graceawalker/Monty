using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private MongoCollection<BsonDocument> _accounts;
        private MongoDatabase _montyTestDb;


        public AccountRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _accounts = _montyTestDb.GetCollection("accounts");
        }


        public virtual void AddNew(Account credit)
        {
            _accounts.Insert(credit);
        }

        public void ClearAll()
        {
            _montyTestDb.GetCollection("accounts").Drop();
        }

        public void DeleteBy(string name)
        {
            var query = new QueryDocument("Name", name);
            _accounts.Remove(query);
        }

        public virtual IEnumerable<Account> GetAll()
        {
            return _accounts.FindAllAs<Account>();
        }

        public Account GetByName(string name)
        {
            var query = new QueryDocument("Name", name);
            return _accounts.FindOneAs<Account>(query);
        }

        public void Update(Account credit)
        {
            _accounts.Save(credit);
        }

        public Account GetById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _accounts.FindOneAs<Account>(query);
        }

        public void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _accounts.Remove(query);
        }
    }
}
