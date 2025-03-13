using PersonalFinance.Domain.Identity;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Implementation
{
    public class AccountUserRoleRepository : GeneralRepository<AccountUserRole>, IAccountUserRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public AccountUserRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<AccountUserRole> Update(AccountUserRole accountUserRole)
        {
            _db.AccountUserRoles.Update(accountUserRole);
            _db.SaveChanges();
            return accountUserRole;
        }
    }
}
