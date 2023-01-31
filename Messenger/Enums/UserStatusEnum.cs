using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    public enum UserStatusEnum : ushort
    {
        Offline = 0,
        Busy = 1,
        Invisible = 2,
        Available = 3
    }
}
