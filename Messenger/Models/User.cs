﻿using System.ComponentModel.DataAnnotations;

namespace Messenger.Models
{
    public partial class User : ICloneable
    {
        public List<MessageUser> Messages { get; set; } = new(); // was created for database syntax
        public List<Room> Rooms { get; set; } = new(); // was created for database syntax
        public string Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public bool IsWriting { get; set; }
        public int StatusId { get; set; }
        public UserStatus? Status { get; set; }
        
        public User()
        { }

        public User(string? name, string login, string? password)
        {
            Name = name;
            Login = login;
            Password = password;
        }

        public object Clone() => new User(Name, Login, Password);
        public override string ToString() => $"Name: {Name}, Login: {Login}, Password: {Password}";
        public override bool Equals(object? obj)
        {
            if (obj is not User obj2 || !GetType().Equals(obj.GetType()))
                return false;
            else return Login.Equals(obj2.Login);
        }
    }
}
