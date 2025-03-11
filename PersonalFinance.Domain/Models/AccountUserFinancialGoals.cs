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
        public int Id { get; set; }

        public virtual AccountUser? AccountUser { get; set; }

        public string AccountUserId { get; set; }

        public virtual FinancialGoals? FinancialGoals { get; set; }

        public int FinancialGoalsId { get; set; }

    }
}
