using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Identity
{
    public class Auth
    {

        [JsonIgnore]
        public int AccountUserId { get; set; }

        public string au_username { get; set; }

        [JsonIgnore]
        public string au_password { get; set; }

        //[JsonIgnore]
        //public string au_password_salt { get; set; }

        public string Token { get; set; }



    }
}
