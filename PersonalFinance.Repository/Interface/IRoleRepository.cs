using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Interface
{
    public interface IRoleRepository : IGeneralRepository<Role>
    {
        public Task<Role> Update(Role role);

    }
}
