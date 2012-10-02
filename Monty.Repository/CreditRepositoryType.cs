using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public class CreditRepositoryType : RepositoryType<Credit>
    {
        private MongoCollection<BsonDocument> _credits;


        public CreditRepositoryType(bool isTesting):base(isTesting)
        {
            _credits = Database.GetCollection("credit");
        }


        public override Credit AddNew(Credit entity)
        {
            _credits.Insert(entity);
            return GetById(entity.Id);
        }

        public override void ClearAll()
        {
            Database.GetCollection("credit").Drop();
        }

        public override Credit GetByName(string name)
        {
            var query = new QueryDocument("Name", name);
            return _credits.FindOneAs<Credit>(query);
        }

        public override IEnumerable<Credit> GetAll()
        {
            return _credits.FindAllAs<Credit>();
        }

        public override void Update(Credit credit)
        {
            _credits.Save(credit);
        }

        public override Credit GetById(string id)
        {
            var query = new QueryDocument("_id", id);
            return _credits.FindOneAs<Credit>(query);
        }

        public override void DeleteBy(string name)
        {
            var query = new QueryDocument("Name", name);
            _credits.Remove(query);
        }


        public override void DeleteById(string id)
        {
            var query = new QueryDocument("_id", id);
            _credits.Remove(query);
        }
    }
}
