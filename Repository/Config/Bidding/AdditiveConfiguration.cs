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
    public class AdditiveConfiguration : IEntityTypeConfiguration<Additive>
    {
        public void Configure(EntityTypeBuilder<Additive> builder)
        {
            builder.ToTable("Additive");

            builder.HasKey(u => u.AdditiveId);

            builder.Property(u => u.AdditiveId)
                .HasColumnType("BIGINT");
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnType("VARCHAR");
            builder.Property(u => u.Number)
                .IsRequired()
                .HasColumnType("INT");
            builder.Property(u => u.Year)
                .IsRequired()
                .HasColumnType("INT")
                .HasMaxLength(4);
            builder.Property(u => u.Description)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(512);
            builder.Property(u => u.Justification)
                .HasColumnType("VARCHAR")
                .HasMaxLength(2048);
            builder.Property(u => u.TotalValue)
                .HasColumnType("DECIMAL");
            builder.Property(u => u.Date)
                .HasColumnType("datetime");
            builder.Property(u => u.Closed)
                .HasColumnType("TINYINT")
                .HasMaxLength(1);

            builder.HasOne(c => c.Contract)
                .WithMany(a => a.Additives)
                .HasForeignKey(c => c.ContractId);

            builder.HasMany(c => c.AdditiveClauses)
                .WithOne(a => a.Additive);

            builder.HasOne(s => s.AdditiveSpreadsheet);

            //builder.HasMany(au => au.AdditiveUsers)
            //    .WithOne(a => a.Additive);






        }
    }
}
