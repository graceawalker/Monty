using System;
using MongoDB.Bson;
using Monty.DAL;
using System.Collections.Generic;
namespace Monty.Repository
{
    public interface IPayPeriodRepository
    {
        void AddNew(PayPeriod newPeriod);
        void ClearAllPayPeriods();
        void Delete(string name);
        IEnumerable<PayPeriod> GetAllPayPeriods();
        PayPeriod GetPayPeriodByName(string payPeriodName);
        void Update(PayPeriod payPeriod);
        PayPeriod GetPayPeriodById(string id);
    }
}
