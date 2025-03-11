using Microsoft.AspNetCore.Identity;
using PersonalFinance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Identity
{
    public class AccountUser: IdentityUser
    {
        public string Token;
        //to finish up 

        public List<FinancialGoals?> AccontUserFinancialGoalList { get; set; }

        public List<Budget?> AccountUserBudgetList { get; set; }
    }
}
