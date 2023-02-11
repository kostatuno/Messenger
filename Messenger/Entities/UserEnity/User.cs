﻿using Messenger.Data;
using Messenger.Entities.ChatEntity;
using Messenger.Entities.MessageEntity;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Entities.UserEnity
{
    public class User : ICloneable
    {
        public ICollection<MessageUser>? Messages { get; set; } // was created for database syntax
        public ICollection<GroupChat>? GroupChats { get; set; } // was created for database syntax
        public ICollection<PersonalChat>? PersonalChatsFromSelf { get; set; } // was created for database syntax
        public ICollection<PersonalChat>? PersonalChatsFromInterlocutor { get; set; } // was created for database syntax
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool IsWriting { get; set; }
        public int StatusId { get; set; }
        public UserStatus? Status { get; set; }

        public User()
        {
        }

        public User(string login, string password, string name)
        {
            StatusId = 1;
            Login = login;
            Password = password;
            Name = name;
        }

        public void CreateGroupChat(string nameChat, params string[] logins)
        {
            using (var db = new ApplicationDbContext())
            {

            }
        }

        public void CreatePersonalChat(string login)
        {
            using (var db = new ApplicationDbContext())
            {
                var interlocutor = db.Users.FirstOrDefault(p => p.Login == login);
                
                if (interlocutor is null)
                    throw new Exception("There is no such login");
                else
                {
                    var chat = new PersonalChat(this, interlocutor);
                    db.PersonalChats.Add(chat);
                    db.SaveChanges();
                }
            }
        }

        public void SendMessage(Chat chat)
        {
            
        }

        public object Clone() => new User(Name!, Login, Password);
        public override string ToString() => $"Name: {Name}, Login: {Login}, Password: {Password}";
        public override bool Equals(object? obj)
        {
            if (obj is not User obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Login.Equals(obj2.Login);
        }
        public override int GetHashCode() => (Login, Password, Name).GetHashCode();  
    }
}
