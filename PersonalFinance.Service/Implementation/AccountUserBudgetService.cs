using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
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

        public async Task<AccountUserBudget> Update(int Id, AccountUserBudget accountUserBudget)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.AccountUserId = obj.AccountUserId;
            obj.BudgetId = obj.BudgetId;
            obj.Categoryid = obj.Categoryid;

            return await ((AccountUserBudgetRepository)_repository).Update(obj);
        }
    }
}
