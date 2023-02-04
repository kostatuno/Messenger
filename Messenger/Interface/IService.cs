using Messenger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Interface
{
    public abstract class IService
    {
        protected ApplicationDbContext db { get; set; }
        public abstract void Run();
    }
}
