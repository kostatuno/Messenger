using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class StatusMessage
    {
        public int Id { get; set; } 
        public string Status { get; private set; }
        public StatusMessage(StatusMessageEnum statusMessage)
        {
            Status = statusMessage.ToString();
        }

        public override string ToString()
        {
            return $"StatusMessage: {Status}";
        }
    }
}
