using BigSister.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSister.Repository.Configuration
{
    internal class ConstantValueConfiguration : IEntityTypeConfiguration<ConstantValue>
    {
        public void Configure(EntityTypeBuilder<ConstantValue> builder)
        {
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.Section).IsRequired().HasMaxLength(50);
        }
    }
}
