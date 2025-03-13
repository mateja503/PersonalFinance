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
    public class AccountUserRepository : GeneralRepository<AccountUser>, IAccountUserRepository
    {

        private readonly ApplicationDbContext _db;

        public AccountUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<AccountUser> Update(AccountUser accountUser)
        {
            _db.AccountUsers.Update(accountUser);
            _db.SaveChanges();
            return accountUser;
        }
    }
}
