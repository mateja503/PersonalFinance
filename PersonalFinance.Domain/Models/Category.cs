using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class Category
    {
        public int Id { get; set; } 

        public string? categoryName { get; set; }

        public virtual List<Transaction?> TransactionList { get; set; }

        public virtual List<AccountUserBudget?> AccountUserBudgetList { get; set; }

    }
}
