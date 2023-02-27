using Messenger.Data;
using Messenger.Entities.UserEnity;
using Messenger.Entities.UserManagerEntity;
using Messenger.Exceptions.AuthorizationExceptions;
using Messenger.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Services
{
    public class Authorization : IService
    {
        public IClient Client { get; set; }
        public Authorization(IClient client)
        {
            Client = client;
        }

        public User Validate(string login, string password)
        {
            UserManager.ValidateLogin(login, out User? inBetweenUser);

            if (inBetweenUser is null)
                throw new AuthorizationNotFoundException("Login is not found");
            else if(inBetweenUser!.Password != password)
                throw new AuthorizationWrongPasswordException("Invalid password. Try again");
            
            return inBetweenUser;
        }
    }
}
