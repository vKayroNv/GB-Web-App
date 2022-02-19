﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.EF.Configuration
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("logins");
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Username).IsUnique();
        }
    }
}
