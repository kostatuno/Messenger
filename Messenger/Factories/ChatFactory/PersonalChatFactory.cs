using Messenger.Entities.ChatEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Factories.ChatFactory
{
    public class PersonalChatFactory : ChatFactory
    {
        public PersonalChatFactory()
        { }

        public override Chat Create()
        {
            return new PersonalChat();
        }
    }
}
    