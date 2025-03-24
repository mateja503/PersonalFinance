using PersonalFinance.Domain.Identity;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class AccountUserRoleService : GeneralService<AccountUserRole, IAccountUserRoleRepository>, IAccountUserRoleService
    {
        private readonly IAccountUserRoleRepository _repository;
        public AccountUserRoleService(IAccountUserRoleRepository repository, ApplicationDbContext db) : base(repository)
        {
            _repository =new AccountUserRoleRepository(db);
        }

        public async Task<AccountUserRole> Update(int Id, AccountUserRole accountUserRole)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.AccountUserId = accountUserRole.AccountUserId;
            obj.AccountUserId = accountUserRole.AccountUserId;

            return await ((AccountUserRoleRepository)_repository).Update(obj);
        }

    }
}
