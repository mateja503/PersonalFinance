using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.IdentityService.RoleService
{
    public class RoleService : GeneralService<Role>, IRoleService
    {
        private readonly IGeneralRepository<Role> _repository;


        public RoleService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<Role>();
        }

        public async Task<Role> Update(int Id, Role role)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.UserRole = role.UserRole;

            
            return await ((RoleRepository)_repository).Update(obj);

        }
    }
}
