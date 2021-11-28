using Domain.Entities.Bidding.PriceReference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config.Bidding.PriceReference
{
    public class SourceItemConfiguration : IEntityTypeConfiguration<SourceItem>
    {
        public void Configure(EntityTypeBuilder<SourceItem> builder)
        {
            builder.ToTable("SourceItem");

            builder.HasKey(si => si.SourceItemId);

            builder.Property(si => si.SourceItemId)
                .HasColumnType("bigint");
            builder.Property(si => si.Code)
                .HasColumnType("varchar")
                .HasMaxLength(32);
            builder.Property(si => si.Description)
                .HasColumnType("varchar")
                .HasMaxLength(256);
            builder.Property(si => si.Unit)
                .HasColumnType("varchar")
                .HasMaxLength(128);
            builder.Property(si => si.ManPower)
                .HasColumnType("decimal");
            builder.Property(si => si.Material)
                .HasColumnType("decimal");
            builder.Property(si => si.TotalUnitValue)
                .HasColumnType("decimal");

            builder.HasOne(s => s.Source)
                .WithMany(si => si.SourceItems)
                .HasForeignKey(si => si.SourceId);

            builder.HasMany(i => i.Inputs)
                .WithOne(si => si.SourceItem);


        }
    }
}
