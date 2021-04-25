using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.Auth
{
    public class AuthenticationResult
    {

        public string Token { get; set; }
        public bool Succes { get; set; }
        public string ErrorMessage { get; set; }

    }
}
