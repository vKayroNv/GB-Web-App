using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Entities.Models;

namespace Timesheets.Storage.EF.Configuration
{
    public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("tokens");
            builder.HasKey(t => t.Id);
            builder.Ignore(t => t.Comment);
            builder.Ignore(t => t.IsDeleted);
            builder.Ignore(t => t.IsExpired);
        }
    }
}
