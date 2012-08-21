using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.DAL;

namespace Monty.Repository
{
    public class AccountCreditRepository : Monty.Repository.IAccountCreditRepository
    {
        private MongoCollection<BsonDocument> _accountCredits;
        private MongoDatabase _montyTestDb;


        public AccountCreditRepository()
        {
            var server = MongoServer.Create();
            _montyTestDb = server.GetDatabase("montytest");
            _accountCredits = _montyTestDb.GetCollection("accountcredit");
        }


        public void ClearAllAccountCredits()
        {
            _montyTestDb.GetCollection("accountcredit").Drop();
        }

        public virtual void AddNew(AccountCredit credit)
        {
            _accountCredits.Insert(credit);
        }

        public AccountCredit GetAccountCreditByName(string accountCreditName)
        {
            var query = new QueryDocument("Name", accountCreditName);
            return _accountCredits.FindOneAs<AccountCredit>(query);

        }

        public virtual IEnumerable<AccountCredit> GetAllAccountCredits()
        {
            return _accountCredits.FindAllAs<AccountCredit>();
        }

        public void Update(AccountCredit accountCredit)
        {
            _accountCredits.Save(accountCredit);
        }

        public AccountCredit GetAccountCreditById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _accountCredits.FindOneAs<AccountCredit>(query);
        }

        public void Delete(string name)
        {
            var query = new QueryDocument("Name", name);
            _accountCredits.Remove(query);
        }


        public void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _accountCredits.Remove(query);
        }
    }
}
