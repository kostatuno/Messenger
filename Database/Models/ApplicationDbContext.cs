using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShkiperMessenger;
using System.Drawing;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        private static ApplicationDbContext applicationDbContext;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MessageUser> Messages { get; set; } = null!;
        public DbSet<StatusMessage> StatusMessage { get; set; } = null!;
        
        private ApplicationDbContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (StatusMessageEnum statusEnum in Enum.GetValues(typeof(StatusMessageEnum)).Cast<StatusMessageEnum>())
            {
                StatusMessage status = new StatusMessage
                {
                    Id = (int)statusEnum,
                    Name = statusEnum.ToString(),
                };
                modelBuilder.Entity<StatusMessage>().HasData(status);
            }
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
            /*var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));*/
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}
