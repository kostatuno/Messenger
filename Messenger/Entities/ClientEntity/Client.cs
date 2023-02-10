using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Entities.UserEnity;

namespace Messenger.Entities.ClientEntity
{
    public abstract class Client
    {
        public User? User { get; set; }
        public abstract void RunWelcome();
        public abstract void RunReady();
    }
}
