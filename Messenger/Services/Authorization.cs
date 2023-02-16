using Messenger.Data;
using Messenger.Entities.ClientEntity;
using Messenger.Entities.UserEnity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Services
{
    public class Authorization : Service
    {
        public Authorization()
        {
        }

        public override void Run(Client client)
        {
            var input = ConsoleInputDataAboutUser();
            User? user;

            using (var db = new ApplicationDbContext())
            {
                user = db.Users
                    .FirstOrDefault(u => u.Login == input.Login && u.Password == input.Password);
                db.SaveChanges();
            }
            
            if (user is not null)
            {
                client.User = user;
                client.RunReady();
            }
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

            return new User() { Login = login!, Password = password! };
        }
    }
}
