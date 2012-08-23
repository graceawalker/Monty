using System;
using MongoDB.Bson;
using Monty.Model.DAL;
using System.Collections.Generic;
namespace Monty.Repository
{
    public interface IRepository<T>
    {
        void AddNew(T entity);
        void ClearAll();
        void DeleteBy(string name);
        IEnumerable<T> GetAll();
        T GetByName(string name);
        void Update(T entity);
        T GetById(string id);
        void DeleteById(string id);
    }
}
