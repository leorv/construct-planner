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
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("Level");

            builder.HasKey(l => l.LevelId);

            builder.Property(l => l.LevelId)
                .HasColumnType("bigint");
            builder.Property(l => l.Name)
                .HasColumnType("varchar")
                .HasMaxLength(64)
                .IsRequired();

            builder.HasOne(s => s.Spreadsheet)
                .WithMany(l => l.Levels)
                .HasForeignKey(s => s.SpreadsheetId);

            builder.HasMany(si => si.SpreadsheetItems)
                .WithOne(l => l.Level);
        }
    }
}
