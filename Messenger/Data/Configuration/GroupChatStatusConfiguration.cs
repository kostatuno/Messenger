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
    public class GroupChatStatusConfiguration : IEntityTypeConfiguration<GroupChatStatus>
    {
        public void Configure(EntityTypeBuilder<GroupChatStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Status);

            builder.HasData(
                new GroupChatStatus(GroupChatStatusEnum.Сlosed) { Id = 1 },
                new GroupChatStatus(GroupChatStatusEnum.Open) { Id = 2 },
                new GroupChatStatus(GroupChatStatusEnum.Full) { Id = 3 }
                );

            builder.ToTable("GroupChatStatus");
        }
    }
}
