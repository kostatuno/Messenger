using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Entities.ChatEntity
{
    public class PersonalChatConfiguration : IEntityTypeConfiguration<PersonalChat>
    {
        public void Configure(EntityTypeBuilder<PersonalChat> builder)
        {
            builder.Ignore(p => p.Length);

            builder
                .HasOne(p => p.FirstUser)
                .WithMany(p => p.PersonalChats)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.SecondUser)
                .WithMany(p => p.PersonalChats)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
