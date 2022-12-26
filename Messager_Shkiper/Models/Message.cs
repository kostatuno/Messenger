using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkiper
{
    class Message : ICloneable
    {
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public StatusMessage Status;

        public Message(User user, string text, DateTime date, StatusMessage status)
        {
            User = user;
            Text = text;
            Date = date;
            Status = status;
        }

        public override string ToString() => $"{User.Name}: {Text}"; 

        public override bool Equals(object? obj)
        {
            if (obj is not Message obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Text.Equals(obj2.Text) && Date.Equals(obj2.Date) && Status.Equals(obj2.Status);
        }

        public object Clone() => new Message(User, Text, Date, Status);
    }
}
