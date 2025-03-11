using PersonalFinance.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class AccountUserFinancialGoals
    {
        

        public AccountUser? AccountUser { get; set; }

        public int? AccountUserId { get; set; }

        public FinancialGoals? FinancialGoals { get; set; }

        public int? FinancialGoalsId { get; set; }

    }
}
