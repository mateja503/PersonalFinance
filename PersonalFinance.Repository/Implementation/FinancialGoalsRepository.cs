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
    public class FinancialGoalsRepository : GeneralRepository<FinancialGoals>, IFinancialGoalsRepository
    {
        private readonly ApplicationDbContext _db;
        public FinancialGoalsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<FinancialGoals> Update(FinancialGoals financialGoals)
        {
            _db.FinancialGoals.Update(financialGoals);
            await _db.SaveChangesAsync();
            return financialGoals;
        }
    }
}
