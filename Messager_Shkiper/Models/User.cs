using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkiper
{
    class User
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
    }
}
