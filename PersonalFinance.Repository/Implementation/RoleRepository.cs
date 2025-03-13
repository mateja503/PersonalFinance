using PersonalFinance.Domain.Identity.RoleManager;
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
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Role> Update(Role role)
        {
            _db.Roles.Update(role);
            _db.SaveChanges();
            return role;
        }
    }
}
