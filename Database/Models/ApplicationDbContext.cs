using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shkiper_Messenger.Extensions;
using ShkiperMessenger;
using System.Drawing;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        private static ApplicationDbContext applicationDbContext;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MessageUser> Messages { get; set; } = null!;
        
        private ApplicationDbContext() 
        {
            Database.EnsureCreated();
        }

        public static ApplicationDbContext GetInstance()
        {
            if (applicationDbContext == null || IsDisposed())
            {
                applicationDbContext = new ApplicationDbContext();
            }
            return applicationDbContext;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var pathDb = Path.Combine(currentDirectory.GetParents(4), @"Database\bin\Debug\net6.0\database.db");

            optionsBuilder.UseSqlite($"Data Source={pathDb}");
        }
    }
}
