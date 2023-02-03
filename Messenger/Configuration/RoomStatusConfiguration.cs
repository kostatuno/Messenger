using Messenger;
using Messenger.Entities;
using Messenger.EntitiesStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Configuration
{
    public class RoomStatusConfiguration : IEntityTypeConfiguration<RoomStatus>
    {
        public void Configure(EntityTypeBuilder<RoomStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Status);

            builder.HasData(
                new RoomStatus(RoomStatusEnum.Сlosed) { Id = 1 },
                new RoomStatus(RoomStatusEnum.Open) { Id = 2 },
                new RoomStatus(RoomStatusEnum.Full) { Id = 3 }
                );
        }
    }
}
