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
    public class AdditiveSpreadsheetItemConfiguration : IEntityTypeConfiguration<AdditiveSpreadsheetItem>
    {
        public void Configure(EntityTypeBuilder<AdditiveSpreadsheetItem> builder)
        {
            builder.ToTable("AdditiveSpreadsheetItem");

            builder.HasKey(si => si.AdditiveSpreadsheetItemId);

            builder.Property(si => si.AdditiveSpreadsheetItemId)
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
                .HasMaxLength(8);
            builder.Property(si => si.ManPower)
                .HasColumnType("decimal");
            builder.Property(si => si.Material)
                .HasColumnType("decimal");

            builder.HasOne(l => l.AdditiveLevel)
                .WithMany(si => si.AdditiveSpreadsheetItems)
                .HasForeignKey(si => si.AdditiveLevelId);
        }
    }
}
