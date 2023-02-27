using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Exceptions
{
    public class AuthorizationNotFoundException : Exception
    {
        public AuthorizationNotFoundException(string message) 
            : base(message) { }
    }
}
