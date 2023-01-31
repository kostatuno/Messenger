using System.ComponentModel.DataAnnotations;

namespace Messenger.Models
{
    public partial class User : ICloneable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        
        public bool IsWriting { get; set; }
        public User()
        {
        }

        public User(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }

        public User(int id, string name, string login, string password)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
        }

        public object Clone() => new User(Id, Name, Login, Password);
        public override string ToString() => $"Name: {Name}, Login: {Login}, Password: {Password}";
        public override bool Equals(object? obj)
        {
            if (obj is not User obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Name.Equals(obj2) && Login.Equals(obj2) && Password.Equals(obj2);
        }
    }
}
