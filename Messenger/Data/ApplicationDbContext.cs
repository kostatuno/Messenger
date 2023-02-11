using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Messenger.Extensions;
using Microsoft.Extensions.Logging;
using Messenger.Entities.ChatEntity;
using Messenger.Entities.MessageEntity;
using Messenger.Entities.UserEnity;
using Messenger.Data.Configuration;
using System.Drawing;

namespace Messenger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PersonalChat> PersonalChats { get; set; } = null!;
        public DbSet<Moderator> Moderators { get; set; } = null!;
        public DbSet<GroupChat> GroupChats { get; set; } = null!;
        public DbSet<GroupChatStatus> GroupChatStatus { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalChatConfiguration());
            modelBuilder.ApplyConfiguration(new GroupChatConfiguration());
            modelBuilder.ApplyConfiguration(new GroupChatStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MessageUserConfiguration());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.UseCollation("Cyrillic_General_CI_AS_KS");
        }
    }
}
