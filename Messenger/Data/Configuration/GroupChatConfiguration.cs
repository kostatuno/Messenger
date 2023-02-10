using Messenger.Entities.ChatEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Configuration
{
    public class GroupChatConfiguration : IEntityTypeConfiguration<GroupChat>
    {
        public void Configure(EntityTypeBuilder<GroupChat> builder)
        {
            builder
                .HasMany(p => p.Users)
                .WithMany(p => p.GroupChats)
                .UsingEntity(j => j.ToTable("Users_GroupChats"));

            builder
                .HasOne(p => p.Moderator)
                .WithOne(p => p.GroupChat)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}