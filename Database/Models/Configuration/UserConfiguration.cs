using Messenger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.UseTphMappingStrategy();
            builder.HasKey(p => p.Login);

            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
