using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.MessageEntity
{
    public class MessageStatus
    {
        public int Id { get; set; }
        public string Status { get; private set; }

        public MessageStatus()
        { }

        public MessageStatus(MessageStatusEnum status)
        {
            Status = status.ToString();
        }

        public override string ToString()
        {
            return $"MessageStatus: {Status}";
        }
    }
}
