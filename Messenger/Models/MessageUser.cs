using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShkiperMessenger
{
    public class MessageUser : ICloneable
    {
        [Key]
        public int Id { get; set; } 
        public User? User { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }

        public StatusMessage? Status;

        public MessageUser()
        {
        }

        public MessageUser(User user, string text, DateTime date, StatusMessage status)
        {
            User = user;
            Text = text;
            Date = date;
            Status = status;
        }

        public override string ToString() => $"{User.Name}: {Text}"; 

        public override bool Equals(object? obj)
        {
            if (obj is not MessageUser obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Text.Equals(obj2.Text) && Date.Equals(obj2.Date) && Status.Equals(obj2.Status);
        }

        public object Clone() => new MessageUser(User, Text, Date, Status);
    }
}
