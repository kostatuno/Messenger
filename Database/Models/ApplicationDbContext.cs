using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Messenger.Extensions;
using Messenger.Models;
using System.Drawing;
using Database.Configuration;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        static ApplicationDbContext? applicationDbContext;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<RoomStatus> RoomStatus { get; set; } = null!;
        public DbSet<MessageUser> Messages { get; set; } = null!;
        public DbSet<MessageStatus> StatusMessege { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Messenger(Shkiper);Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageUserConfiguration());
        }
        private static bool IsDisposed()
        {
            try
            {
                applicationDbContext.Database.EnsureCreated();
            }
            catch
            {
                return true;
            }
            return false;
        }

        private ApplicationDbContext() 
        {
        }

        public static ApplicationDbContext GetInstance()
        {
            if (applicationDbContext == null || IsDisposed())
            {
                applicationDbContext = new ApplicationDbContext();
            }
            return applicationDbContext;
        }  
    }
}
