using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Data;
using Messenger.Entities.UserEnity;
using Messenger.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Messenger.Services
{
    public class Registration : IService
    {
        public IClient Client { get; set; }

        public Registration(IClient client)
        {
            Client = client;
        }

        public void CreateAccount(User user)
        {
            using var db = new ApplicationDbContext();
            db.Users.Add(user);
            db.SaveChanges();
        }


        User ConsoleInputInformationAboutNewAccount()
        {
            Console.WriteLine("\nRegistration\n");
            Console.WriteLine($"Login: ");
            var login = Console.ReadLine();
            Console.WriteLine($"Name: ");
            var name = Console.ReadLine();
            Console.WriteLine($"Password: ");
            var password = Console.ReadLine();
            Console.WriteLine($"Password again: ");
            var pwAgain = Console.ReadLine();

            if (password != pwAgain)
            {
                Console.WriteLine("Your passwords aren't equal. Try again");
                ConsoleInputInformationAboutNewAccount();
            }

            return new User(login, password, name);
        }
    }
}
