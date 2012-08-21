using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class AccountDebitRepository : IAccountDebitRepository
    {
        private MongoCollection<BsonDocument> _accountDebits;
        private MongoDatabase _montyTestDb;


        public AccountDebitRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _accountDebits = _montyTestDb.GetCollection("accountdebit");
        }


        public void ClearAllAccountDebits()
        {
            _montyTestDb.GetCollection("accountdebit").Drop();
        }

        public virtual void AddNew(AccountDebit credit)
        {
            _accountDebits.Insert(credit);
        }

        public AccountDebit GetAccountDebitByName(string accountDebitName)
        {
            var query = new QueryDocument("Name", accountDebitName);
            return _accountDebits.FindOneAs<AccountDebit>(query);

        }

        public virtual IEnumerable<AccountDebit> GetAllAccountDebits()
        {
            return _accountDebits.FindAllAs<AccountDebit>();
        }

        public void Update(AccountDebit accountCredit)
        {
            _accountDebits.Save(accountCredit);
        }

        public AccountDebit GetAccountDebitById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _accountDebits.FindOneAs<AccountDebit>(query);
        }

        public void Delete(string name)
        {
            var query = new QueryDocument("Name", name);
            _accountDebits.Remove(query);
        }


        public void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _accountDebits.Remove(query);
        }
    }
}
