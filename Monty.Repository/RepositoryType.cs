using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Monty.Model.DAL;
using System.Collections.Generic;
namespace Monty.Repository
{
    public abstract class RepositoryType<T>
    {
        public RepositoryType():this(false)
        {
            
        }

        public RepositoryType(bool isTesting = false)
        {
            var connectionString = isTesting ? "mongodb://localhost/montytest" : "mongodb://localhost/monty";
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var server = MongoServer.Create(connectionString);
            Database = server.GetDatabase(databaseName);
        }

        protected MongoDatabase Database { get; set; }
        public abstract T AddNew(T entity);
        public abstract void ClearAll();
        public abstract void DeleteBy(string name);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByName(string name);
        public abstract void Update(T entity);
        public abstract T GetById(string id);
        public abstract void DeleteById(string id);
    }
}
