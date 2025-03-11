using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public DateTime BudgetMonth { get; set; }
        public double? budgetAmount { get; set; }
        public List<AccountUserBudget?> AccountUserBudgetList { get; set; }
        public int Year => BudgetMonth.Year;
        public int Month => BudgetMonth.Month;

    }
}
