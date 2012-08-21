using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Monty.DAL;

namespace Monty.UI.Models
{
    public class AccountCreditModel
    {
        public IEnumerable<AccountCredit> AccountCredits { get; set; } 
    }
}