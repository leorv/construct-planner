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
    public class InputConfiguration : IEntityTypeConfiguration<Input>
    {
        public void Configure(EntityTypeBuilder<Input> builder)
        {
            builder.ToTable("Input");

            builder.HasKey(i => i.InputId);

            builder.Property(i => i.InputId)
                .HasColumnType("bigint");
            builder.Property(i => i.Code)
                .HasColumnType("varchar")
                .HasMaxLength(32);
            builder.Property(i => i.Description)
                .HasColumnType("varchar")
                .HasMaxLength(256);
            builder.Property(i => i.Unit)
                .HasColumnType("varchar")
                .HasMaxLength(8);
            builder.Property(i => i.Type)
                .HasColumnType("char")
                .HasMaxLength(1);
            builder.Property(i => i.Price)
                .HasColumnType("decimal");
            builder.Property(i => i.Amount)
                .HasColumnType("double");

            builder.HasOne(s => s.Source)
                .WithMany(i => i.Inputs)
                .HasForeignKey(i => i.SourceId);
            builder.HasOne(si => si.SourceItem)
                .WithMany(i => i.Inputs)
                .HasForeignKey(i => i.SourceItemId);

        }
    }
}
