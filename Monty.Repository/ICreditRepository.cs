using System;
using MongoDB.Bson;
using Monty.Model.DAL;
using System.Collections.Generic;
namespace Monty.Repository
{
    public interface ICreditRepository
    {
        void AddNew(Credit credit);
        void ClearAllCredits();
        void Delete(string name);
        IEnumerable<Credit> GetAllCredits();
        Credit GetCreditByName(string creditName);
        void Update(Credit credit);
        Credit GetCreditById(string id);
        void DeleteById(string id);
    }
}
