using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Monty.DAL;

namespace Monty.UI.Models.PayPeriodModels
{
    public class PayPeriodModel
    {
        public PayPeriod PayPeriod { get; set; }

        public IEnumerable<PayPeriod> ExistingPayPeriods { get; set; }
    }
}