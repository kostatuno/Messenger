using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Entities;

namespace Messenger.Interface
{
    public interface IModerator : IUser
    {
        void OfferToRemoveUser(Voting voting);
    }
}
