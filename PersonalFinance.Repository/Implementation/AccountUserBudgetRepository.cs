using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Implementation
{
    public class AccountUserBudgetRepository : GeneralRepository<AccountUserBudget>, IAccountUserBudgetRepository
    {
        private readonly ApplicationDbContext _db;

        public AccountUserBudgetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<AccountUserBudget> Update(AccountUserBudget accountUserBudget)
        {
            _db.AccountUserBudgets.Update(accountUserBudget);
            await _db.SaveChangesAsync();
            return accountUserBudget;
        }
    }
}
