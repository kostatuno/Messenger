﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Data;
using Messenger.Entities.ClientEntity;
using Messenger.Entities.UserEnity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Messenger.Services
{
    public class Registration : Service
    {
        public User? User { get; set; }
        
        public Registration()
        {
        }

        public void CreateAccount(User user)
        {
            using var db = new ApplicationDbContext();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public override void Run(Client client)
        {
            var user = ConsoleInputInformationAboutNewAccount();
            CreateAccount(user);
            client.RunWelcome();
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
