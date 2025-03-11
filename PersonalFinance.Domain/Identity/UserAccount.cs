using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Identity
{
    public class UserAccount : IdentityUser
    {
        public string Token;

    }
}
