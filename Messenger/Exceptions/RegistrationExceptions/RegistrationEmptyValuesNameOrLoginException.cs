using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Exceptions.RegistrationExceptions
{
    public class RegistrationEmptyValuesNameOrLoginException : Exception
    {
        public RegistrationEmptyValuesNameOrLoginException(string message)
            : base(message) { }
    }
}
