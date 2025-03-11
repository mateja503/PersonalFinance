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
    public class AccountUserFinancialGoalsRepository : GeneralRepository<AccountUserFinancialGoals>, IAccountUserFinancialGoals
    {
        private readonly ApplicationDbContext _db;

        public AccountUserFinancialGoalsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<AccountUserFinancialGoals> Update(AccountUserFinancialGoals accountUserFinancialGoals)
        {
            _db.AccountUserFinancialGoals.Update(accountUserFinancialGoals);
            await _db.SaveChangesAsync();
            return accountUserFinancialGoals;
        }
    }
}
