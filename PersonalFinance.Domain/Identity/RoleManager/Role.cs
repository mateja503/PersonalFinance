using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalFinance.Domain.Identity.RoleManager.Enumiration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Identity.RoleManager
{
    public class Role
    {
        public int Id { get; set; }

        public RoleEnum  UserRole { get; set; }

        public virtual List<AccountUserRole> AccountUsers { get; set; }



    }
}
