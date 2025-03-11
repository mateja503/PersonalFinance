using PersonalFinance.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class AccountUserBudget
    {
        public int Id { get; set; }
        public AccountUser?  AccountUser { get; set; }

        public int? AccountUserId { get; set; }

        public Budget? Budget { get; set; }
        public int? BudgetId { get; set; }

        public int? CategoryTransactionId { get; set; }

    }
}
