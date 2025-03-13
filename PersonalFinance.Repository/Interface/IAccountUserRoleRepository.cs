
using PersonalFinance.Domain.Identity;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Interface
{
    public interface IAccountUserRoleRepository : IGeneralRepository<AccountUserRole>
    {
        public Task<AccountUserRole> Update(AccountUserRole accountUserRole);

    }
}
