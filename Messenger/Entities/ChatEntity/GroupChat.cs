using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Entities.MessageEntity;
using Messenger.Entities.UserEnity;

namespace Messenger.Entities.ChatEntity
{
    public class GroupChat : Chat
    {
        public ICollection<User> Users { get; set; }
            = new HashSet<User>(); // was created for database syntax
        public string Name { get; set; } = null!;
        public int StatusId { get; set; }
        public GroupChatStatus? Status { get; set; } // was created for database syntax
        public string? ModeratorId { get; set; }
        [ForeignKey("ModeratorId")]
        public Moderator? Moderator { get; set; } // was created for database syntax
        public int Length { get; protected init; }

        public GroupChat()
        { }

        public GroupChat(User moderator, string name, int length)
        {
            Name = name;
            Length = length;
            Users = new List<User>(length);
            Moderator = new Moderator(moderator);
            AddUser(moderator);
        }

        public void AddUser(User user)
        {
            if (Users.Contains(user))
                throw new Exception("User is already existing");

            if (Users.Count < Length)
            {
                Users.Add(user);
            }
            else throw new Exception("Room is full");
        }

        public void RemoveUser(int id)
        {
        }
    }
}
