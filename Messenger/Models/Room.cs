using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Moderator Moderator { get; set; }
        public List<User> Users { get; set; }
        public int Length { get; private set; }
        public Room(string name, int length)
        {
            Name = name;
            Length = length;
            Users = new List<User>(length);
        }

        public void AddUser(int id)
        {
            if (Users.Contains(new User() { Id = id }))
                throw new Exception("User is already existing");
        }

        public void RemoveUser(int id)
        {
        }
    }
}
