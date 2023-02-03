using Messenger.Interface;
using Messenger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities
{
    public class ConsoleClient
    {
        List<IService> services;
        public ConsoleClient()
        {
            services = new List<IService>();
            services.Add(new Authorization());
            services.Add(new Registration());
            Run();
        }

        public void Run()
        {
            Console.WriteLine($"You are welcome. It's your Shkiper\n");

            for (int i = 0; i < services.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {services[i].GetType().Name}");
            }

            Console.WriteLine("\nSelect your action (number):");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out int answer);

                if (answer <= 0 || answer > services.Count)
                    Console.WriteLine("\rIncorrect input. Try again");
                else
                {
                    services[answer-1].Run();
                    break;
                }
            }
        }
    }
}
