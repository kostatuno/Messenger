using Messenger.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Configuration
{
    public class MessageUserConfiguration : IEntityTypeConfiguration<MessageUser>
    {
        public void Configure(EntityTypeBuilder<MessageUser> builder)
        {
            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Messages)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
