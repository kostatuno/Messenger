using Messenger.Data;
using Messenger.Entities.ChatEntity;
using Messenger.Entities.FriendRequestEntity;
using Messenger.Entities.MessageEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Messenger.Entities.UserEnity
{
    public class User : ICloneable
    {
        public ICollection<FriendRequest> MyRequests { get; set; }
            = new HashSet<FriendRequest>(); // was created for database syntax
        /*public ICollection<FriendRequest> ItsRequests { get; set; }
            = new HashSet<FriendRequest>(); // was created for database syntax*/
        public ICollection<User> MyFriends { get; set; }
            = new HashSet<User>(); // was created for database syntax
        public ICollection<User> ItsFriends { get; set; }
            = new HashSet<User>(); // was created for database syntax
        public ICollection<MessageUser> Messages { get; set; } 
            = new HashSet<MessageUser>(); // was created for database syntax
        public ICollection<GroupChat> GroupChats { get; set; } 
            = new HashSet<GroupChat>(); // was created for database syntax
        public ICollection<PersonalChat> PersonalChatsFromSelf { get; set; } 
            = new HashSet<PersonalChat>(); // was created for database syntax
        public ICollection<PersonalChat> PersonalChatsFromInterlocutor { get; set; } 
            = new HashSet<PersonalChat>(); // was created for database syntax
        public ICollection<GroupChat> ModeratorOfGroupChats { get; set; }
            = new HashSet<GroupChat>(); // was created for database syntax

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

        public void CreateGroupChat(string nameChat, int length, params string[] logins)
        {
            if (logins.Length > length)
                throw new Exception
                    ("Count users that you want adding to GroupChat is more than the specified chat length");

            using (var db = new ApplicationDbContext())
            {
                foreach (var login in logins)
                {
                    var users = db.Users.Where(p => p.Login == login).ToList();
                    db.GroupChats.Add(new GroupChat(this, nameChat, length));
                    db.SaveChanges();
                }
            }
        }

        public void CreatePersonalChat(string login)
        {
            using (var db = new ApplicationDbContext())
            {
                if (PersonalChatsFromSelf.Any(u => u.SecondUserLogin == login))
                    throw new Exception("There is already the chat");

                var interlocutor = db.Users
                    .FirstOrDefault(p => p.Login == login);

                if (interlocutor is null)
                    throw new Exception("There is no such login");
                else
                {
                    var chat = new PersonalChat(this, interlocutor);
                    interlocutor.PersonalChatsFromInterlocutor.Add(chat);
                    PersonalChatsFromSelf.Add(chat);
                    db.Update(chat);
                    db.SaveChanges(); 
                }
            }
        }

        public void SendMessageTo(User user, string text)
        {
            using (var db = new ApplicationDbContext())
            {
                var chat = PersonalChatsFromSelf.FirstOrDefault(p => p.SecondUser!.Equals(user));
                if (chat is not null)
                {
                    chat.Messages.Add(new MessageUser(this, text));
                    db.SaveChanges();
                }
                else CreatePersonalChat(user.Login);
            }
        }

        public void DeleteChat(Chat chat, bool deleteForAll)
        {
            using var db = new ApplicationDbContext();
            if (chat is GroupChat gChat)
            {
                GroupChats.Remove(gChat);
                if (this is Moderator)
                {
                    db.Users.Select(p => p.GroupChats.Remove(gChat));
                }
            }
            else if (chat is PersonalChat pChat)
            {
                PersonalChatsFromSelf.Remove(pChat);
                if (deleteForAll)
                {
                    PersonalChatsFromInterlocutor.Remove(pChat);
                }
            }
            db.SaveChanges();
        }

        public void BlockUser(User user)
        {

        }

        public void ClearMessages(Chat chat, bool deleteForAll)
        {

        }

        public void SendFriendRequest(string login)
        {

        }

        private void AddToFriends(string login)
        {
            using (var db = new ApplicationDbContext())
            {
                if (MyFriends.Any(u => u.Login == login))
                    throw new Exception("This user is already your friend");

                var interlocutor = db.Users
                    .FirstOrDefault(p => p.Login == login);

                if (interlocutor is null)
                    throw new Exception("There is no such login");
                else
                {

                }
            }
        }

        public void LeaveChat(Chat chat)
        {

        }

        public void CreateVotingKickTheUser(User user)
        {

        }

        public void AddUserToGroupChat(string nameGroupChat, string login)
        {
            using var db = new ApplicationDbContext();
            
            var chat = GroupChats.FirstOrDefault(p => p.Name == nameGroupChat);
            var user = db.Users.FirstOrDefault(p => p.Login == login);

            if (chat is null)
                throw new Exception("There is no such chat where you are");

            else if (user is null)
                throw new Exception("There is no such user");

            if (!chat.IsFull)
            {
                chat.AddUser(user);
            }
        }
            
        public object Clone()
        {
            User user = (User)this.MemberwiseClone();
            return user;
        }

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
