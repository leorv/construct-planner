using Domain.Entities.Bidding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config.Bidding
{
    public class SpreadsheetConfiguration : IEntityTypeConfiguration<Spreadsheet>
    {
        public void Configure(EntityTypeBuilder<Spreadsheet> builder)
        {
            builder.ToTable("Spreadsheet");

            builder.HasKey(s => s.SpreadsheetId);

            builder.Property(s => s.SpreadsheetId)
                .HasColumnType("bigint");

            builder.Property(s => s.Name)
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(s => s.Title)
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(s => s.Description)
                .HasColumnType("varchar")
                .HasMaxLength(1024);
            builder.Property(s => s.Author)
                .HasColumnType("varchar")
                .HasMaxLength(128);
            builder.Property(s => s.Date)
                .HasColumnType("datetime");
            builder.Property(s => s.EncumberType)
                .HasColumnType("char")
                .HasMaxLength(2);

            builder.HasOne(c => c.Contract)
                .WithMany(s => s.Spreadsheets)
                .HasForeignKey(s => s.ContractId);

            builder.HasOne(a => a.Additive);

            builder.HasMany(a => a.Addresses)
                .WithOne(s => s.Spreadsheet);

            builder.HasMany(l => l.Levels)
                .WithOne(s => s.Spreadsheet);

        }
    }
}
