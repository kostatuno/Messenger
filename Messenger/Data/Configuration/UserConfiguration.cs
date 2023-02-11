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
            builder.UseTpcMappingStrategy();

            builder.HasKey(p => p.Login);
            builder.Ignore(p => p.IsWriting);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Password).IsRequired();

            builder
                .HasMany(p => p.GroupChats)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.ToTable("Users_GroupChats"));

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
