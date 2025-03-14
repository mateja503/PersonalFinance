using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.IdentityService.RoleService
{
    public interface IRoleService : IGeneralService<Role>
    {
        public Task<Role> Update(int Id, Role role);
    }
}
