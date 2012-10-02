using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class AccountRepositoryType : RepositoryType<Account>
    {
        private MongoCollection<BsonDocument> _accounts;

        public AccountRepositoryType(bool isTesting):base(isTesting)
        {
            _accounts = Database.GetCollection("account");
        }

        public override Account AddNew(Account credit)
        {
            _accounts.Insert(credit);
            return GetById(credit.Id);
        }

        public override void ClearAll()
        {
            _accounts.Drop();
        }

        public override void DeleteBy(string name)
        {
            var query = new QueryDocument("Name", name);
            _accounts.Remove(query);
        }

        public override IEnumerable<Account> GetAll()
        {
            return _accounts.FindAllAs<Account>();
        }

        public override Account GetByName(string name)
        {
            var query = new QueryDocument("Name", name);
            return _accounts.FindOneAs<Account>(query);
        }

        public override void Update(Account credit)
        {
            _accounts.Save(credit);
        }

        public override Account GetById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _accounts.FindOneAs<Account>(query);
        }

        public override void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _accounts.Remove(query);
        }
    }
}
