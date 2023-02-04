using Messenger.Data;
using Messenger.Entities.ClientEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Services
{
    public abstract class Service
    {
        protected ApplicationDbContext db { get; set; }
        public abstract void Run(Client client);
    }
}
