using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monty.Model.DAL;

namespace Monty.Repository
{
    public interface IDebitRepository
    {
        void ClearAllDebits();
        void AddNew(Debit credit);
        Debit GetDebitByName(string debitName);
        IEnumerable<Debit> GetAllDebits();
        void Update(Debit credit);
        Debit GetDebitById(string id);
        void Delete(string name);
        void DeleteById(string id);
    }

}
