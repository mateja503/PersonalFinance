﻿using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Interface
{
    public interface IFinancialGoalsService : IGeneralService<FinancialGoals>
    {
        public Task<bool> CheckGoalReached(int Id, double amount, int year, int month);

        public Task<FinancialGoals> Update(int Id, FinancialGoals financialGoals);

    }
}
