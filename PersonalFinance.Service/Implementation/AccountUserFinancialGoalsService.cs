using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class AccountUserFinancialGoalsService : GeneralService<AccountUserFinancialGoals, IAccountUserFinancialGoalsRepository>, IAccountUserFinancialGoalsService
    {
        private readonly IAccountUserFinancialGoalsRepository _repository;

        public AccountUserFinancialGoalsService(IAccountUserFinancialGoalsRepository repository, ApplicationDbContext db) : base(repository)
        {
            _repository = new AccountUserFinancialGoalsRepository(db);
        }

        public async Task<AccountUserFinancialGoals> Update(int Id, AccountUserFinancialGoals accountUserFinancialGoals)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.FinancialGoalsId = accountUserFinancialGoals.FinancialGoalsId;
            obj.AccountUserId = accountUserFinancialGoals.AccountUserId;

            return await ((AccountUserFinancialGoalsRepository)_repository).Update(obj);
        }
    }
}
