using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Identity
{
    public class AccountUser
    {
        public int Id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }

        public double amount { get; set; }

        public virtual List<AccountUserRole> Roles { get; set; }
        public virtual List<AccountUserFinancialGoals?> AccontUserFinancialGoalList { get; set; }

        public virtual Auth UserAuthentication { get; set; }

        public virtual List<AccountUserBudget?> AccountUserBudgetList { get; set; }
    }
}
