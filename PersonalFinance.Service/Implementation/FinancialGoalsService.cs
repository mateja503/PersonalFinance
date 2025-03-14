using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class FinancialGoalsService : GeneralService<FinancialGoals>, IFinancialGoalsService
    {
        private readonly IGeneralRepository<FinancialGoals> _repository;

        public FinancialGoalsService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<FinancialGoals>();
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
