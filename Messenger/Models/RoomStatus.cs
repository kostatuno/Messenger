using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class RoomStatus
    {
        public int Id { get; set; }
        public string Status { get; private set; }

        public RoomStatus()
        { }
        
        public RoomStatus(RoomStatusEnum status)
        {
            Status = status.ToString();
        }

        public override string ToString()
        {
            return $"RoomStatus: {Status}";
        }
    }
}
