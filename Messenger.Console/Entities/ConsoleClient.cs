﻿using Messenger.Entities.ClientEntity;
using Messenger.Entities.UserEnity;
using Messenger.Extensions;
using Messenger.Interface;
using Messenger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Console.Entities
{
    public class ConsoleClient : Client
    {
        List<Service> services;
       /* public User? User
        {
            get
            {
                if (User is null)
            }
            private set
            {

            }
        }*/

        public ConsoleClient(params Service[] iServices)
        {
            services = new List<Service>();
            foreach (var service in iServices)
            {
                services.Add(service);
            }
            RunWelcome();
        }

        public override void RunReady()
        {
            MethodInfo[] methods = typeof(User).GetCreatedMethods();

            System.Console.WriteLine("\nYou are welcome" +
                "\nWhat do you want?\n");

            for (int i = 0; i < methods.Length; i++)
            {
                System.Console.WriteLine($"{i + 1}. {methods[i].Name}");
            }

            while (true)
            {
                int.TryParse(System.Console.ReadLine(), out int answer);

                if (answer <= 0 || answer > methods.Length)
                    System.Console.WriteLine("\rIncorrect input. Try again");
                else
                {
                    
                    break;
                }
            }
        }

        public override void RunWelcome()
        {
            var welcomeClient = new StringBuilder();
            welcomeClient.AppendLine($"You are welcome. It's your Shkiper\n");

            for (int i = 0; i < services.Count; i++)
            {
                welcomeClient.AppendLine($"{i + 1}. {services[i].GetType().Name}");
            }

            welcomeClient.Append("\nSelect your action (number):");

            System.Console.WriteLine(welcomeClient.ToString());

            while (true)
            {
                int.TryParse(System.Console.ReadLine(), out int answer);

                if (answer <= 0 || answer > services.Count)
                    System.Console.WriteLine("\rIncorrect input. Try again");
                else
                {
                    services[answer - 1].Run(this);
                    break;
                }
            }
        }
    }
}
