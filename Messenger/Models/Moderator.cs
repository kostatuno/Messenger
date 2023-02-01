using Messenger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class Moderator : User, IModerator
    {
        public Room? Room;

        public Moderator()
        { }

        public Moderator(User user) : base(user.Name, user.Login, user.Password)
        { }

        public void OfferToRemoveUser(IUser user)
        {

        }
    }
}
