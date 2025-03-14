using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.IdentityService.IdentityException
{
    internal class UserWithUserNemeExistsException : Exception
    {
        public UserWithUserNemeExistsException()
        {
        }

        public UserWithUserNemeExistsException(string? message) : base($"The user with username {message} already exists")
        {
        }
    }
}
