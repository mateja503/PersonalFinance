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
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class FinancialGoalsService : GeneralService<FinancialGoals, IFinancialGoalsRepository>, IFinancialGoalsService
    {
        private readonly IFinancialGoalsRepository _repository;

        public FinancialGoalsService(IFinancialGoalsRepository repository, ApplicationDbContext db) : base(repository)
        {
            _repository = new FinancialGoalsRepository(db);
        }

        public async Task<bool> CheckGoalReached(int Id, double amount,int year, int month)
        {
            var obj = await _repository.Get(u => u.Id == Id);
            var result = amount >= obj?.amountGoal && DateTime.UtcNow.Year <= year && DateTime.UtcNow.Month <= month;

            _repository.Detach();
            return result;
        }

        public async Task<FinancialGoals> Update(int Id, FinancialGoals financialGoals)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.goalText = financialGoals.goalText;
            obj.amountGoal = financialGoals.amountGoal;
            obj.goalReachInTime = financialGoals.goalReachInTime;
            obj.AccountUserFinancialGoalList = financialGoals.AccountUserFinancialGoalList;

            return await ((FinancialGoalsRepository)_repository).Update(obj);

        }
    }
}
