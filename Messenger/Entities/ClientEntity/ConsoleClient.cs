using Messenger.Interface;
using Messenger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.ClientEntity
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
            Console.WriteLine("");
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

            Console.WriteLine(welcomeClient.ToString());

            while (true)
            {
                int.TryParse(Console.ReadLine(), out int answer);

                if (answer <= 0 || answer > services.Count)
                    Console.WriteLine("\rIncorrect input. Try again");
                else
                {
                    services[answer - 1].Run(this);
                    break;
                }
            }
        }
    }
}
