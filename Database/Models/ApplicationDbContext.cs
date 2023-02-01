using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Messenger.Extensions;
using Messenger.Models;
using System.Drawing;
using Database.Models.Configuration;
using Microsoft.Extensions.Logging;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; } = null!;
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
                .SetBasePath(new DirectoryInfo(Directory.GetCurrentDirectory()).GetParents(3))
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .EnableDetailedErrors()
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageUserConfiguration());

            modelBuilder.UseCollation("Cyrillic_General_CI_AS_KS");
        }
    }
}
