using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
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
    }
}
