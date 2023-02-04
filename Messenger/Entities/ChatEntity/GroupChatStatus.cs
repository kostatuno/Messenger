using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.ChatEntity
{
    public class GroupChatStatus
    {
        public int Id { get; set; }
        public string Status { get; private set; }

        public GroupChatStatus()
        { }

        public GroupChatStatus(GroupChatStatusEnum status)
        {
            Status = status.ToString();
        }

        public override string ToString()
        {
            return $"RoomStatus: {Status}";
        }
    }
}
