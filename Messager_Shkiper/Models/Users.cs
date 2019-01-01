using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkiper
{
    class Users
    {
        public List<User> List = new List<User>();
        public User this[int i]
        {
            get { return List[i]; }
            set { List[i] = value; }
        }

        public void AddFromLog(string path)
        {
            var users = File.ReadLines(path);
            foreach (var user in users)
            {
                var elements = user.Split('|');
                if (user.Contains('|'))
                    List.Add(new User(elements[0], elements[1], elements[2]));
            }
        }
    }
}
