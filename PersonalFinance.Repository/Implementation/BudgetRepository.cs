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
    public class BudgetRepository : GeneralRepository<Budget>, IBudgetRepository
    {
        private readonly ApplicationDbContext _db;

        public BudgetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Budget> Update(Budget budget)
        {
            _db.Budgets.Update(budget);
            await _db.SaveChangesAsync();
            return budget;
        }
    }
}
