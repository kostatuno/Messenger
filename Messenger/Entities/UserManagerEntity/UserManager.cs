using Messenger.Data;
using Messenger.Entities.UserEnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.UserManagerEntity
{
    public class UserManager
    {
        public static bool ValidateLogin(string login, out User? user)
        {
            using (var db = new ApplicationDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.Login == login);
                return user is null ? false : true;
            }
        }

    }
}
