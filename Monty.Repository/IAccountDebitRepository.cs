using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public interface IAccountDebitRepository
    {
        void ClearAllAccountDebits();
        void AddNew(AccountDebit credit);
        AccountDebit GetAccountDebitByName(string accountDebitName);
        IEnumerable<AccountDebit> GetAllAccountDebits();
        void Update(AccountDebit accountCredit);
        AccountDebit GetAccountDebitById(string id);
        void Delete(string name);
        void DeleteById(string id);
    }

}
