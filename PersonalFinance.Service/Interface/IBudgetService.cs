using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Interface
{
    public interface IBudgetService: IGeneralService<Budget>
    {
        public Task<double> GetTheBudgetAmmountForMonthInEveryYear(int month);

        public Task<double> GetTheBudgetForTheWholeYear(int year);
        public Task<double> GetTheBudgetForMonthInYear(int year,int month);

        public Task<Budget> TakeOutOfTheBudget(int Id, double amount);

        public Task<Budget> AddToTheBudget(int Id, double amount);

        public Task<bool> OverTheBudget(int Id);

        public Task<double> GetTheBudgetAmount(int Id);

    }
}
