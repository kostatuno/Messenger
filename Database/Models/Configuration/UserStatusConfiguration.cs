using Messenger;
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
    public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Status);

            builder.HasData(
                new UserStatus(UserStatusEnum.Offline) { Id = 1 },
                new UserStatus(UserStatusEnum.Busy) { Id = 2 },
                new UserStatus(UserStatusEnum.Invisible) { Id = 3 },
                new UserStatus(UserStatusEnum.Available) { Id = 4 }
                );
        }
    }
}
