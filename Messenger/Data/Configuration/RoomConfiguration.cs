using Messenger.Entities;
using Messenger.EntitiesStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasMany(p => p.Users)
                .WithMany(p => p.Rooms)
                .UsingEntity(j => j.ToTable("UsersRooms"));

            builder
                .HasOne(p => p.Moderator)
                .WithOne(p => p.Room)
                .OnDelete(DeleteBehavior.SetNull);

            //
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
