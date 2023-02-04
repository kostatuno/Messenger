using Messenger.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.ChatEntity
{
    public class GroupChatConfiguration : IEntityTypeConfiguration<GroupChat>
    {
        public void Configure(EntityTypeBuilder<GroupChat> builder)
        {
            builder
                .HasMany(p => p.Users)
                .WithMany(p => p.Rooms)
                .UsingEntity(j => j.ToTable("UsersRooms"));

            builder
                .HasOne(p => p.Moderator)
                .WithOne(p => p.Chat)
                .OnDelete(DeleteBehavior.SetNull);

            //
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}