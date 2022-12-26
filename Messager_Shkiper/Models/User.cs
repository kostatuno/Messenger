using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shkiper
{
    public class User : ICloneable
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User(string name, string login, string password)
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
            else return Name.Equals(obj2) && Login.Equals(obj2) && Password.Equals(obj2);
        }
    }
}
