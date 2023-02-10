using Messenger.Entities.ChatEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Factories.ChatFactory
{
    public class GroupChatFactory : ChatFactory
    {
        public GroupChatFactory() { }

        public override Chat Create()
        {
            return new GroupChat();
        }
    }
}
