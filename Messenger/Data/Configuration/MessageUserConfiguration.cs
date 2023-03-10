using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Entities.MessageEntity;

namespace Messenger.Data.Configuration
{
    public class MessageUserConfiguration : IEntityTypeConfiguration<MessageUser>
    {
        public void Configure(EntityTypeBuilder<MessageUser> builder)
        {
            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Messages)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasMany(p => p.GroupChats)
                .WithMany(p => p.Messages)
                .UsingEntity(j => j.ToTable("GroupChats_Messages"));

            builder
                .HasMany(p => p.PersonalChats)
                .WithMany(p => p.Messages)
                .UsingEntity(j => j.ToTable("PersonalChats_Messages"));

            builder.Property(p => p.Text).HasMaxLength(200);
        }
    }
}
