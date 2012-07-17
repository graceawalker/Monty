using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Monty.DAL;

namespace Monty.UI.Models.PayPeriodModels
{
    public class PayPeriodViewModel
    {
        public PayPeriod PayPeriod
        {
            get
            {
                return PayPeriodMapper.GetPayPeriodFromModel(PayPeriodModel);
            }
            set
            {
                PayPeriodModel = PayPeriodMapper.GetModelFromPayPeriod(value);
            }
        }
        public PayPeriodModel PayPeriodModel { get; set; }
        public IEnumerable<PayPeriod> ExistingPayPeriods { get; set; }
    }

    public static class PayPeriodMapper
    {
        public static PayPeriod GetPayPeriodFromModel(PayPeriodModel model)
        {
            return new PayPeriod(model.PayPeriodName, model.StartDate.Date.ToShortDateString(), model.EndDate.Date.ToShortDateString());
        }

        public static PayPeriodModel GetModelFromPayPeriod(PayPeriod value)
        {
            return new PayPeriodModel() { PayPeriodName = value.PayPeriodName, EndDate = value.EndDate, StartDate = value.StartDate };
        }
    }
}