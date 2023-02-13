using Messenger.Entities.ChatEntity;
using Messenger.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.UserEnity
{
    public class Moderator : User, IModerator
    {
        public void KickTheUser(User user)
        {

        }

        public Moderator()
        { }

        public Moderator(User user) : base(user.Name, user.Login, user.Password)
        { }

        public void RemoveUser(User user)
        {

        }
    }
}
