using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.IdentityService.IdentityException
{
    internal class LogInFailedException : Exception
    {
        public LogInFailedException() : base("Login attemtp failed")
        {
        }
    }
}
