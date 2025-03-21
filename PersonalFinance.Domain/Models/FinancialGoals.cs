﻿using PersonalFinance.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class FinancialGoals
    {
        public int Id { get; set; }

        public string goalText { get; set; }
        public DateTime goalReachInTime { get; set; }

        public double amountGoal { get; set; }

        public virtual List<AccountUserFinancialGoals?> AccountUserFinancialGoalList { get; set; }

        public int Year => goalReachInTime.Year;
        public int Month => goalReachInTime.Month;

    }
}
