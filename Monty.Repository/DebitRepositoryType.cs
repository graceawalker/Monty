using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class DebitRepositoryType : RepositoryType<Debit>
    {
        private MongoCollection<BsonDocument> _debits;


        public DebitRepositoryType(bool isTesting):base(isTesting)
        {
            _debits = Database.GetCollection("debit");
        }


        public override Debit AddNew(Debit credit)
        {
            _debits.Insert(credit);
            return GetById(credit.Id);
        }

        public override void ClearAll()
        {
            Database.GetCollection("debit").Drop();
        }

        public override void DeleteBy(string name)
        {
            var query = new QueryDocument("Name", name);
            _debits.Remove(query);
        }

        public override IEnumerable<Debit> GetAll()
        {
            return _debits.FindAllAs<Debit>();
        }

        public override Debit GetByName(string name)
        {
            var query = new QueryDocument("Name", name);
            return _debits.FindOneAs<Debit>(query);
        }

        public override void Update(Debit credit)
        {
            _debits.Save(credit);
        }

        public override Debit GetById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _debits.FindOneAs<Debit>(query);
        }

        public override void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _debits.Remove(query);
        }
    }
}
