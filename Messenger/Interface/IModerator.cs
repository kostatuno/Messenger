using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Entities.UserEnity;

namespace Messenger.Interface
{
    public interface IModerator : IUser
    {
        void RemoveUser(User user);
    }
}
