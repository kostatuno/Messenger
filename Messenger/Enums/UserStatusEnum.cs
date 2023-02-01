using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    public enum UserStatusEnum : ushort
    {
        Offline = 1,
        Busy,
        Invisible,
        Available
    }
}
