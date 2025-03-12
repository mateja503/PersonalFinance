using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Interface
{
    public interface IAccountUserFinancialGoalsService: IGeneralService<AccountUserFinancialGoals>
    {

        public Task<bool> CheckFinancialGoalReached(AccountUserFinancialGoals accountUserFinancialGoals, double amount);


    }
}
