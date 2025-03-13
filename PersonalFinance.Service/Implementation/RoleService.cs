using PersonalFinance.Domain.Identity.RoleManager;
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
    public class RoleService : GeneralService<Role>, IRoleService
    {

        private readonly IGeneralRepository<Role> _repository;
        public RoleService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<Role>();
        }
    }
}
