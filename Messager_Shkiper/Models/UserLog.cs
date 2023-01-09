using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Shkiper
{
    public static class UserLog
    {
        public static List<User> List = new List<User>();
        public static void AddFromLog(string path)
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
