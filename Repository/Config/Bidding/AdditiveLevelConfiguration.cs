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
    public class AdditiveLevelConfiguration : IEntityTypeConfiguration<AdditiveLevel>
    {
        public void Configure(EntityTypeBuilder<AdditiveLevel> builder)
        {
            builder.ToTable("AdditiveLevel");

            builder.HasKey(l => l.AdditiveLevelId);

            builder.Property(l => l.AdditiveLevelId)
                .HasColumnType("bigint");
            builder.Property(l => l.Name)
                .HasColumnType("varchar")
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(l => l.Title)
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();

            builder.HasOne(s => s.AdditiveSpreadsheet)
                .WithMany(l => l.AdditiveLevels)
                .HasForeignKey(s => s.AdditiveSpreadsheetId);

            builder.HasMany(si => si.AdditiveSpreadsheetItems)
                .WithOne(l => l.AdditiveLevel);
        }
    }
}
