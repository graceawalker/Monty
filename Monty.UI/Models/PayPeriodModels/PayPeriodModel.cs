using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Monty.UI.Models.PayPeriodModels
{
    public class PayPeriodModel
    {
        [DisplayName("Name")]
        public string PayPeriodName { get; set; }
        [DisplayName("Start Date")]
        public DateTimeOffset StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTimeOffset EndDate { get; set; }
    }
}
