using Messenger.Entities.UserEnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.FriendRequestEntity
{
    public class FriendRequest
    {
        public string FromLogin { get; set; } = null!;
        public User? FirstUser { get; set; }
        public string ToLogin { get; set; } = null!;
        public User? SecondUser { get; set; }
        
        public FriendRequest()
        { }

        public FriendRequest(string fromLogin, string toLogin)
        {
            FromLogin = fromLogin;
            ToLogin = toLogin;
        }
    }
}
