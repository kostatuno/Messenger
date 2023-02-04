using Messenger.Entities.ChatEntity;
using Messenger.Entities.MessageEntity;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Entities.UserEnity
{
    public class User : ICloneable
    {
        public IList<MessageUser> Messages { get; set; } // was created for database syntax
        public IList<GroupChat> GroupChats { get; set; } // was created for database syntax
        public IList<PersonalChat> PersonalChats { get; set; } // was created for database syntax
        public string Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public bool IsWriting { get; set; }
        public int StatusId { get; set; }
        public UserStatus? Status { get; set; }

        public User()
        { }

        public User(string login, string? password, string? name)
        {
            StatusId = 1;
            Login = login;
            Password = password;
            Name = name;
        }

        public object Clone() => new User(Name, Login, Password);
        public override string ToString() => $"Name: {Name}, Login: {Login}, Password: {Password}";
        public override bool Equals(object? obj)
        {
            if (obj is not User obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Login.Equals(obj2.Login);
        }
    }
}
