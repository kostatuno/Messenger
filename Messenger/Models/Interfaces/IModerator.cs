using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Interfaces
{
    interface IModerator
    {
        void OfferToRemoveUser(IUser user);
    }
}
