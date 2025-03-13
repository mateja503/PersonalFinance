using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class AccountUserFinancialGoalsService : GeneralService<AccountUserFinancialGoals>, IAccountUserFinancialGoalsService
    {
        private readonly IGeneralRepository<AccountUserFinancialGoals> _repository;

        public AccountUserFinancialGoalsService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<AccountUserFinancialGoals>();
        }

     
    }
}
