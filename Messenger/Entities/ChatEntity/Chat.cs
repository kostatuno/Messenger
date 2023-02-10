using Messenger.Entities.MessageEntity;
using Messenger.Entities.UserEnity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.ChatEntity
{
    public abstract class Chat
    {
        public int Id { get; set; }
        public int Length { get; protected init; }
        public ICollection<MessageUser>? Messages { get; set; }
    }
}
