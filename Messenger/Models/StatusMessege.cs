﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class MessageStatus
    {
        public int Id { get; set; } 
        public string Status { get; private set; }
        public MessageStatus(MessageStatusEnum statusMessage)
        {
            Status = statusMessage.ToString();
        }

        public override string ToString()
        {
            return $"StatusMessage: {Status}";
        }
    }
}
