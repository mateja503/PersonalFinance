using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.IdentityService.IdentityException
{
    internal class FormNotCompletelyEnteredException : Exception
    {
        public FormNotCompletelyEnteredException() : base("Please enter all of the input fields")
        {
            
        }
    }
}
