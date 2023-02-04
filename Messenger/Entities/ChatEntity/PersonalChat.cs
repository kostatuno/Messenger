using Messenger.Entities.UserEnity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.ChatEntity
{
    public class PersonalChat : Chat
    {
        public int FirstUserId { get; set; }
        public User? FirstUser { get; init; }
        public int SecondUserId { get; set; }
        public User? SecondUser { get; init; }
        public PersonalChat(User firstUser, User secondUser)
        {
            FirstUser = firstUser;
            SecondUser = secondUser;
            Length = 2;
        }

        public PersonalChat()
        { }
    }
}
