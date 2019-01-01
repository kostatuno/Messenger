using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkiper
{
    static class UserLogFileManager
    {
        static string path = "LogUsers.txt";
        public static void Add(User user)
        {
            using (var sw = new StreamWriter(new FileStream(path, FileMode.Append)))
            {
                sw.Write($"\n{user.Name}|{user.Login}|{user.Password}");
            }
        }
    }
}
