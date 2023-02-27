using Messenger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Interface
{
    public interface IService
    {
        IClient Client { get; set; }
    }
}
