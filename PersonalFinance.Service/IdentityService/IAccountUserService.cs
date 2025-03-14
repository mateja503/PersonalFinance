using PersonalFinance.Domain.Identity;
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
        public Task<AccountUser> Login(string username, string password);
        public Task<AccountUser> Register(string username, string email, string password, string name, string surname);
    }
}
