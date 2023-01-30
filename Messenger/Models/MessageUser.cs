using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Models
{
    public class MessageUser : ICloneable
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public User? User { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public MessageUser()
        {
        }

        public MessageUser(User user, 
            string text, 
            DateTime date, 
            StatusMessageEnum status = StatusMessageEnum.NotRead)
        {
            User = user;
            UserId = user.Id;
            Text = text;
            Date = date;
            Status = Enum.GetName(typeof(StatusMessageEnum), status);
        }

        public override string ToString() => $"{User.Name}: {Text} | {Date:HH:mm:ss}"; 

        public override bool Equals(object? obj)
        {
            if (obj is not MessageUser obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Text.Equals(obj2.Text) && Date.Equals(obj2.Date) && Status.Equals(obj2.Status);
        }

        public object Clone() => new MessageUser(User, Text, Date, StatusMessageEnum.NotRead);
    }
}
