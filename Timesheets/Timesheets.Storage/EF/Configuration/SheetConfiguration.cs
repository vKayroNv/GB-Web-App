using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Entities.Models;

namespace Timesheets.Storage.EF.Configuration
{
    public sealed class SheetConfiguration : IEntityTypeConfiguration<Sheet>
    {
        public void Configure(EntityTypeBuilder<Sheet> builder)
        {
            builder.ToTable("sheets");
            builder.HasKey(t => t.Id);
        }
    }
}
