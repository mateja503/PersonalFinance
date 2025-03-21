using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.UserRegistryModel;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.IdentityService
{
    public interface IAccountUserService : IGeneralService<AccountUser>
    {
        public Task<AccountUser> Login(AccountUserLoginModel model);
        public Task<AccountUser> Register(AccoutUserRegistryModel model );

        public Task<AccountUser> Update(int Id, AccountUser accountUser);

        public Task<AccountUser> ValidateSession(string token);
    }
}
