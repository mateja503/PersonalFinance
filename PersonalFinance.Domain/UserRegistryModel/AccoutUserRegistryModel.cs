using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.UserRegistryModel
{
    public class AccoutUserRegistryModel
    {
        public string? username { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
    }
}
