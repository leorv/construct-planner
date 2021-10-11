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
    public class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.ToTable("Source");

            builder.HasKey(s => s.SourceId);

            builder.Property(s => s.SourceId)
                .HasColumnType("bigint");
            builder.Property(s => s.Name)
                .HasColumnType("varchar")
                .HasMaxLength(48);
            builder.Property(s => s.Day)
                .HasColumnType("int")
                .HasMaxLength(2);
            builder.Property(s => s.Month)
                .HasColumnType("int")
                .HasMaxLength(2);
            builder.Property(s => s.Year)
                .HasColumnType("int")
                .HasMaxLength(4);
            builder.Property(s => s.SourceFamily)
                .HasColumnType("varchar")
                .HasMaxLength(64);
            builder.Property(s => s.EncumberType)
                .HasColumnType("char")
                .HasMaxLength(2);

            builder.HasMany(si => si.SourceItems)
                .WithOne(s => s.Source);
            builder.HasMany(i => i.Inputs)
                .WithOne(s => s.Source);
        }
    }
}
