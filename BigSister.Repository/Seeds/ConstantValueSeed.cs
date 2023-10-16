using BigSister.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigSister.Repository.Seeds
{
    internal class ConstantValueSeed : IEntityTypeConfiguration<ConstantValue>
    {
        public void Configure(EntityTypeBuilder<ConstantValue> builder)
        {
            builder.HasData(
                new ConstantValue { Id = 1, Section = "instagram" }, 
                new ConstantValue { Id = 2, Section = "facebook" }, 
                new ConstantValue { Id = 3, Section = "twitter" }, 
                new ConstantValue { Id = 4, Section = "linkedin" }, 
                new ConstantValue { Id = 5, Section = "phone" }, 
                new ConstantValue { Id = 6, Section = "location" }, 
                new ConstantValue { Id = 7, Section = "email" },
                new ConstantValue { Id = 8, Section = "iframeLocation" });
        }
    }
}
