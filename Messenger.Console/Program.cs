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
            var client = new ConsoleClient(
                new Registration(),
                new Authorization());

            /*using (var db = new ApplicationDbContext())
            {
                *//*db.Users.Add(new User("123", "123", "123"));
                db.Users.Add(new User("111", "111", "111"));*//*

                var user = db.Users.FirstOrDefault(u => u.Login == "123");
                var user2 = db.Users.FirstOrDefault(u => u.Login == "111");

                foreach (var item in db.PersonalChats)
                {
                    System.Console.WriteLine(item.Id);
                }

                db.Users.Include(u => u.PersonalChatsFromSelf).Load();

                foreach (var item in user.PersonalChatsFromSelf)
                {
                    System.Console.WriteLine(item.Id);
                }

                System.Console.WriteLine();

                foreach (var item in user2.PersonalChatsFromSelf)
                {
                    System.Console.WriteLine(item.Id);
                }

                *//*var chat = new PersonalChat(user2!, user!);

                db.PersonalChats.Add(chat);
                db.SaveChanges();*//*
            }*/
        }
    }
}