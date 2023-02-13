using Messenger.Entities.MessageEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Configuration
{
    public class MessageStatusConfiguration : IEntityTypeConfiguration<MessageStatus>
    {
        public void Configure(EntityTypeBuilder<MessageStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Status);

            builder.HasData(
                new MessageStatus(MessageStatusEnum.NotRead) { Id = 1 },
                new MessageStatus(MessageStatusEnum.Read) { Id = 2 },
                new MessageStatus(MessageStatusEnum.Changed) { Id = 3 }
                );

            builder.ToTable("MessageStatus");
        }
    }
}
