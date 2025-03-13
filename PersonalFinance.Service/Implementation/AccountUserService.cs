using PersonalFinance.Domain.Identity;
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
    public class AccountUserService : GeneralService<AccountUser>, IAccountUserService
    {
        private readonly IGeneralRepository<AccountUser> _repository; 
        public AccountUserService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<AccountUser>();
        }
    }
}
