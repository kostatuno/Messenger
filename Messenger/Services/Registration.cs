using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Data;
using Messenger.Entities;
using Messenger.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Messenger.Services
{
    public class Registration : IService
    {
        ApplicationDbContext db;
        public User? User { get; set; }
        
        public Registration()
        {
            db = new ApplicationDbContext();
        }

        public void CreateAccount(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            db.Dispose();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
