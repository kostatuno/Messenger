using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class Room
    {
        public List<User> Users { get; set; } = new();
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public RoomStatus? Status { get; set; }
        public string? ModeratorId { get; set; }
        [ForeignKey("ModeratorId")]
        public Moderator? Moderator { get; set; }
        public int Count { get; private set; }

        public Room()
        { }

        public Room(User moderator, string name, int count)
        {
            Name = name;
            Count = count;
            Users = new List<User>(count);
            AddUser(moderator);
        }

        public void AddUser(User user)
        {
            if (Users.Contains(user))
                throw new Exception("User is already existing");

            if (Users.Count < Count)
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
