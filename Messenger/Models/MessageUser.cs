﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Models
{
    public class MessageUser : ICloneable
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public User? User { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public MessageStatus Status { get; set; }

        public MessageUser()
        {
        }

        public MessageUser(User user, 
            string text, 
            DateTime date, 
            MessageStatusEnum status = MessageStatusEnum.NotRead)
        {
            User = user;
            Text = text;
            Date = date;
            Status = new MessageStatus(status);
        }

        public override string ToString() => $"{User.Name}: {Text} | {Date:HH:mm:ss}"; 

        public override bool Equals(object? obj)
        {
            if (obj is not MessageUser obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Text.Equals(obj2.Text) && Date.Equals(obj2.Date) && Status.Equals(obj2.Status);
        }

        public object Clone() => new MessageUser(User, Text, Date, MessageStatusEnum.NotRead);
    }
}
