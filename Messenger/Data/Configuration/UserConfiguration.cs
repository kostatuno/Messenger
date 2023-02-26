using Messenger.Entities.UserEnity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.UseTptMappingStrategy();
            builder.HasKey(p => p.Login);
            builder.Ignore(p => p.IsWriting);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Password).IsRequired();

            builder
                .HasMany(p => p.MyFriends)
                .WithMany(p => p.ItsFriends)
                .UsingEntity(j => j.ToTable("UserFriends"));

            builder
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
