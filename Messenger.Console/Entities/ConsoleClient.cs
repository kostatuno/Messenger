using Messenger.Entities.ClientEntity;
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

            System.Console.WriteLine("\nYou are welcome" +
                "\nWhat do you want?\n");

            System.Console.WriteLine($"1. {nameof(User.CreatePersonalChat)}");
            System.Console.WriteLine($"2. {nameof(User.CreateGroupChat)}");
            System.Console.WriteLine($"3. {nameof(User.SendMessageTo)}");
            System.Console.WriteLine($"4. {nameof(User.DeleteChat)}");

            while (true)
            {
                int.TryParse(System.Console.ReadLine(), out int answer);

                if (answer <= 0 || answer > 5)
                    System.Console.WriteLine("\rIncorrect input. Try again");
                else
                {
                    switch (answer)
                    {
                        case 1:
                            System.Console.WriteLine("Input login your interlocutor: "); 
                            while (true)
                            {
                                string login = System.Console.ReadLine()!;
                                try
                                {
                                    User!.CreatePersonalChat(login);
                                    break;
                                }
                                catch
                                {
                                    System.Console.WriteLine("\rIncorrect input. Try again");
                                }
                            } 
                            break;
                        /*case 2:
                            System.Console.WriteLine("Input name of group chat: ");
                            while (true)
                            {
                                string login = System.Console.ReadLine()!;

                            }
                            User.CreateGroupChat();
                            break;
                        case 3:
                            User.SendMessageTo();
                            break;
                        case 4:
                            User.DeleteChat();
                            break;*/
                        default:
                            break;
                    }
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
