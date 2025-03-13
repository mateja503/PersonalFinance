using PersonalFinance.Domain.Identity;
using PersonalFinance.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Interface
{
    public interface IAccountUserRepository : IGeneralRepository<AccountUser>
    {
        public Task<AccountUser> Update(AccountUser accountUser);
    }
}
