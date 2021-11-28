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
    public class SpreadsheetItemConfiguration : IEntityTypeConfiguration<SpreadsheetItem>
    {
        public void Configure(EntityTypeBuilder<SpreadsheetItem> builder)
        {
            builder.ToTable("SpreadsheetItem");

            builder.HasKey(si => si.SpreadsheetItemId);

            builder.Property(si => si.SpreadsheetItemId)
                .HasColumnType("bigint");

            builder.Property(si => si.Source)
                .HasColumnType("varchar")
                .HasMaxLength(48);
            builder.Property(si => si.Code)
                .HasColumnType("varchar")
                .HasMaxLength(32);
            builder.Property(si => si.Description)
                .HasColumnType("varchar")
                .HasMaxLength(256);
            builder.Property(si => si.Amount)
                .HasColumnType("double");
            builder.Property(si => si.Unit)
                .HasColumnType("varchar")
                .HasMaxLength(128);
            builder.Property(si => si.ManPower)
                .HasColumnType("decimal");
            builder.Property(si => si.Material)
                .HasColumnType("decimal");

            builder.HasOne(l => l.Level)
                .WithMany(si => si.SpreadsheetItems)
                .HasForeignKey(si => si.LevelId);
        }
    }
}
