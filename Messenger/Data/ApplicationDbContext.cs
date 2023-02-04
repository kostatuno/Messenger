﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Messenger.Extensions;
using Messenger.Entities;
using System.Drawing;
using Microsoft.Extensions.Logging;
using Messenger.EntitiesStatus;

namespace Messenger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GroupChat> Rooms { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<RoomStatus> RoomStatus { get; set; } = null!;
        public DbSet<MessageUser> Messages { get; set; } = null!;
        public DbSet<MessageStatus> StatusMessege { get; set; } = null!;

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .EnableDetailedErrors();
                //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageUserConfiguration());*/

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.UseCollation("Cyrillic_General_CI_AS_KS");
        }
    }
}
