using Messenger.Data;
using Messenger.Entities;
using Messenger.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Services
{
    public class Authorization : IService
    {
        public Authorization()
        {
            db = new ApplicationDbContext();
        }

        public bool Validate(User user)
        {
            return db.Users.Any(x => x.Login == user.Login && x.Password == user.Password);
        }

        public override void Run(IClient client)
        {
            var user = ConsoleInputDataAboutUser();

            if (Validate(user))
                client.RunReady();
            else
            {
                Console.WriteLine("\nValidation failed\n");
                client.RunWelcome();
            }
        }

        User ConsoleInputDataAboutUser()
        {
            Console.WriteLine("\nAuthorization\n");
            Console.WriteLine($"Login: ");
            var login = Console.ReadLine();
            Console.WriteLine($"Password: ");
            var password = Console.ReadLine();

            return new User() { Login = login, Password = password };
        }
    }
}
