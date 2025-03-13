using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System.Runtime.InteropServices;


namespace PersonalFinance.Service.Implementation
{
    public class BudgetService : GeneralService<Budget>, IBudgetService
    {
        private readonly IGeneralRepository<Budget> _repository;

        public BudgetService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<Budget>();
        }

      
        public async Task<double> GetTheBudgetAmmountForMonthInEveryYear(int month)
        {
            var objs = await _repository.GetAll(u => u.Month == month);
            double result = objs.Select(u => u.budgetAmount).Sum() ?? 0;
            _repository.Detach();
            return result;
        }

    

        public async Task<double> GetTheBudgetForMonthInYear(int year, int month)
        {
            var obj = await _repository.Get(u => u.Year == year && u.Month == month);
            double result = obj.budgetAmount ?? 0;
            _repository.Detach();
            return result;
        }

        public async Task<double> GetTheBudgetForTheWholeYear(int year)
        {
            var objs = await _repository.GetAll(u => u.Year == year);
            double result = objs.Select(u => u.budgetAmount).Sum() ?? 0;
            _repository.Detach();
            return result;
        }

        public async Task<Budget> TakeOutOfTheBudget(int Id, double amount)
        {
            var obj = await _repository.Get(u => u.Id == Id);
            obj.budgetAmount = obj.budgetAmount - amount;

            var result =  await ((IBudgetRepository)_repository).Update(obj);

            _repository.Detach();

            return result;

        }

        public async Task<Budget> AddToTheBudget(int Id, double amount)
        {
            var obj = await _repository.Get(u => u.Id == Id);
            obj.budgetAmount = obj.budgetAmount + amount;

            var result = await((IBudgetRepository)_repository).Update(obj);

            _repository.Detach();

            return result;
        }

        public async Task<bool> OverTheBudget(int Id)
        {
            var obj = await _repository.Get(u => u.Id == Id);
            var result = obj.budgetAmount < 0;

            _repository.Detach();

            return result;
        }

        public async Task<double> GetTheBudgetAmount(int Id)
        {

            var obj = await _repository.Get(u => u.Id == Id);
            var result = obj.budgetAmount;

            _repository.Detach();
            return result ?? 0;

        }

        public async Task<Budget> Update(int Id, Budget budget)
        {
            var obj = await  _repository.Get(u => u.Id == Id);

            obj.

            return await ((BudgetRepository)_repository).Update()
        }
    }
}
