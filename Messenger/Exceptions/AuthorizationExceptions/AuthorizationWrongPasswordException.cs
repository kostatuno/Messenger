using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Exceptions.AuthorizationExceptions
{
    public class AuthorizationWrongPasswordException : Exception
    {
        public AuthorizationWrongPasswordException(string message)
            : base(message) { }
    }
}
