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
    public class AdditiveSpreadsheetConfiguration : IEntityTypeConfiguration<AdditiveSpreadsheet>
    {
        public void Configure(EntityTypeBuilder<AdditiveSpreadsheet> builder)
        {
            builder.ToTable("AdditiveSpreadsheet");

            builder.HasKey(s => s.AdditiveSpreadsheetId);

            builder.Property(s => s.AdditiveSpreadsheetId)
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

            builder.HasMany(l => l.AdditiveLevels)
                .WithOne(s => s.AdditiveSpreadsheet);

        }
    }
}
