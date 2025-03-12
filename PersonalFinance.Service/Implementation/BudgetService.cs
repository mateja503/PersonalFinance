using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;


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

        public async Task<Budget> TakeOutOfTheBudget(Budget budget, double amount)
        {
            var obj = await _repository.Get(u => u.Id == budget.Id);
            obj.budgetAmount = obj.budgetAmount - amount;

            var result =  await ((IBudgetRepository)_repository).Update(obj);

            _repository.Detach();

            return result;

        }

        public async Task<Budget> AddToTheBudget(Budget budget, double amount)
        {
            var obj = await _repository.Get(u => u.Id == budget.Id);
            obj.budgetAmount = obj.budgetAmount + amount;

            var result = await((IBudgetRepository)_repository).Update(obj);

            _repository.Detach();

            return result;
        }

        public async Task<bool> OverTheBudget(Budget budget)
        {
            var obj = await _repository.Get(u => u.Id == budget.Id);
            var result = obj.budgetAmount < 0;

            _repository.Detach();

            return result;
        }

        public async Task<double> GetTheBudgetAmount(Budget budget)
        {

            var obj = await _repository.Get(u => u.Id == budget.Id);
            var result = obj.budgetAmount;

            _repository.Detach();
            return result ?? 0;

        }
    }
}
