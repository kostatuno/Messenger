using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Data;
using Messenger.Entities.UserEnity;
using Messenger.Exceptions.RegistrationExceptions;
using Messenger.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Messenger.Services
{
    public class Registration : IService
    {
        public IClient Client { get; set; }

        public Registration(IClient client)
        {
            Client = client;
        }

        public void CreateAccount(string name, string login, string pw, string pwAgain)
        {
            if (name == "" || login == "")
                throw new RegistrationEmptyValuesNameOrLoginException
                    ("Name or login have empty values");

            if (pw != pwAgain)
                throw new RegistrationPasswordMismatchException
                    ("Registration did not pass the check for repeating the value of the passport field");

            using var db = new ApplicationDbContext();
            db.Users.Add(new User(login, pw, name));
            db.SaveChanges();
        }
    }
}
