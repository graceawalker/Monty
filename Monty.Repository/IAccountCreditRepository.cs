using System;
using MongoDB.Bson;
using Monty.Model.DAL;
using System.Collections.Generic;
namespace Monty.Repository
{
    public interface IAccountCreditRepository
    {
        void AddNew(AccountCredit credit);
        void ClearAllAccountCredits();
        void Delete(string name);
        IEnumerable<AccountCredit> GetAllAccountCredits();
        AccountCredit GetAccountCreditByName(string accountCreditName);
        void Update(AccountCredit accountCredit);
        AccountCredit GetAccountCreditById(string id);
        void DeleteById(string id);
    }
}
