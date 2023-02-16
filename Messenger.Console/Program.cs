using Microsoft.VisualBasic.FileIO;
using Messenger.Extensions;
using Messenger;
using System.Reflection;
using Messenger.Entities;
using Messenger.Services;
using Messenger.Data;
using Messenger.Entities.ClientEntity;
using Messenger.Console.Entities;
using Messenger.Entities.UserEnity;
using Microsoft.EntityFrameworkCore;
using Messenger.Entities.ChatEntity;

namespace Messenger.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var client = new ConsoleClient(
                new Registration(),
                new Authorization());*/

            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Login == "123");
                var user2 = db.Users.FirstOrDefault(u => u.Login == "111");

                var chat = new PersonalChat(user!, user2!);

                db.PersonalChats.Add(chat);
                db.SaveChanges();
            }
        }
    }
}