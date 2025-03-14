using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.IdentityService.IdentityException
{
    internal class UserWithEmailExistsException : Exception
    {
        public UserWithEmailExistsException()
        {
        }

        public UserWithEmailExistsException(string? message) : base($"The user with email {message} already exists")
        {

        }
    }
}
