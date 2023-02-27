﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Exceptions.AuthorizationExceptions
{
    public class AuthorizationWrongPassword : Exception
    {
        public AuthorizationWrongPassword(string message)
            : base(message) { }
    }
}