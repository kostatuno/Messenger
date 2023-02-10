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
    public class PersonalChatConfiguration : IEntityTypeConfiguration<PersonalChat>
    {
        public void Configure(EntityTypeBuilder<PersonalChat> builder)
        {
            builder.Ignore(p => p.Length);

            builder
                .HasOne(p => p.FirstUser)
                .WithMany(p => p.PersonalChatsFromSelf)
                .HasForeignKey(p => p.FirstUserLogin)
                .HasPrincipalKey(p => p.Login)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.SecondUser)
                .WithMany(p => p.PersonalChatsFromInterlocutor)
                .HasForeignKey(p => p.SecondUserLogin)
                .HasPrincipalKey(p => p.Login)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
