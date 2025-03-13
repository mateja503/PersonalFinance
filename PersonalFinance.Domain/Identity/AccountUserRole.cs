using PersonalFinance.Domain.Identity.RoleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Identity
{
    public class AccountUserRole
    {

        public int Id { get; set; }

        public virtual AccountUser AccountUser { get; set; }

        public int AccountUserId { get; set; }

        public virtual Role Role { get; set; }
        public int? RoleId { get; set; }
    }
}
