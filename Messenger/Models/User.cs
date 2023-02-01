using System.ComponentModel.DataAnnotations;

namespace Messenger.Models
{
    public partial class User : ICloneable
    {
        public List<MessageUser> MessageUser { get; set; } = new();// was created for database syntax
        public string Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public bool IsWriting { get; set; }
        public int UserStatusId { get; set; }
        public UserStatus? UserStatus { get; set; }
        
        public User()
        {}

        public User(string? name, string login, string? password)
        {
            Name = name;
            Login = login;
            Password = password;
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
