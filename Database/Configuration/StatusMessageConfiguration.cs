using Messenger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Configuration
{
    public class StatusMessageConfiguration : IEntityTypeConfiguration<StatusMessage>
    {
        public void Configure(EntityTypeBuilder<StatusMessage> builder)
        {
            builder.HasAlternateKey(p => p.Status);
        }
    }
}
