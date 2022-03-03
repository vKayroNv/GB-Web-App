﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Domain.Models;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.EF.Configuration
{
    public sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoices");
            builder.HasKey(t => t.Id);
        }
    }
}
