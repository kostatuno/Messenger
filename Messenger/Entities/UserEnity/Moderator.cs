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
        public ICollection<GroupChat> ModeratorOfGroupChats { get; set; } 
            = new HashSet<GroupChat>(); // was created for database syntax

        public Moderator()
        { }

        public Moderator(User user) : base(user.Name, user.Login, user.Password)
        { }

        public void RemoveUser(User user)
        {

        }
    }
}
