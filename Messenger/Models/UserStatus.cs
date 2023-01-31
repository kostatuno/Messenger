using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public UserStatus(UserStatusEnum status)
        {
            Status = status.ToString();
        }
    }
}
