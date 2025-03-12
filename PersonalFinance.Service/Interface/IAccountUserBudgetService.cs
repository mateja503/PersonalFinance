using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Interface
{
    public interface IAccountUserBudgetService : IGeneralService<AccountUserBudget>
    {

        public  Task<bool> CheckUserForBudgetExceeded(AccountUserBudget accountUserBudget, double amount);

    }
}
