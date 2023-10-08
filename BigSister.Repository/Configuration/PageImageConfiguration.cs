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
    internal class PageImageConfiguration : IEntityTypeConfiguration<PageImage>
    {
        public void Configure(EntityTypeBuilder<PageImage> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.PageName).IsRequired().HasMaxLength(100);
        }
    }
}
