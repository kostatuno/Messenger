using Microsoft.VisualBasic.FileIO;
using Messenger.Extensions;
using Messenger;
using System.Reflection;
using Messenger.Entities;
using Messenger.Services;
using Messenger.Data;
using Messenger.Entities.ClientEntity;
using Messenger.Console.Entities;

namespace Messenger.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new ConsoleClient(
                new Registration(),
                new Authorization());
        }
    }
}