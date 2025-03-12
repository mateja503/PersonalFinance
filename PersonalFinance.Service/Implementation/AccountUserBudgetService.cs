using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class AccountUserBudgetService : GeneralService<AccountUserBudget>, IAccountUserBudgetService
    {
        private readonly IGeneralRepository<AccountUserBudget> _repository; 

        public AccountUserBudgetService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository =  unitOfWork.GetRepository<AccountUserBudget>();
        }

        public async Task<bool> CheckUserForBudgetExceeded(AccountUserBudget accountUserBudget, double amount)
        {
            var obj = await _repository.Get(u => u.Id == accountUserBudget.Id);

            bool flag = amount > obj?.Budget?.budgetAmount ? true : false;

            _repository.Detach();

            return flag;
        }

  
    }
}
