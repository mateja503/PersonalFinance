using PersonalFinance.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class FinancialGoals
    {
        public int Id { get; set; }

        public string? goalText { get; set; }
        public DateTime? goalReachInTime { get; set; }


        public List<AccountUser?> FinancialGoalsAccountUserList{ get; set; }

    }
}
