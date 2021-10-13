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
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");

            builder.HasKey(c => c.ContractId);

            builder.Property(c => c.ContractId)
                .HasColumnType("BIGINT");
            builder.Property(c => c.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(c => c.Object)
                .HasColumnType("VARCHAR")
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(c => c.Object)
                .HasColumnType("varchar")
                .HasMaxLength(512);
            builder.Property(c => c.Number)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.Year)
                .HasColumnType("int")
                .HasMaxLength(4)
                .IsRequired();
            builder.Property(c => c.Description)
                .HasColumnType("varchar")
                .HasMaxLength(512);            
            builder.Property(c => c.TotalValue)
                .HasColumnType("decimal");
            builder.Property(c => c.Date)
                .HasColumnType("datetime");
            builder.Property(c => c.Closed)
                .HasColumnType("TINYINT")
                .HasMaxLength(1);

            builder.HasOne(u => u.User)
                .WithMany(c => c.Contracts)
                .HasForeignKey(u => u.UserId);

            builder.HasMany(us => us.ContractUsers)
                .WithOne(c => c.Contract);

            builder.HasMany(ca => ca.ContractAgreements)
                .WithOne(c => c.Contract);

            builder.HasMany(cl => cl.Clauses)
                .WithOne(c => c.Contract);

            builder.HasMany(a => a.Additives)
                .WithOne(c => c.Contract);

            builder.HasMany(s => s.Spreadsheets)
                .WithOne(c => c.Contract);

            builder.HasMany(b => b.BDIs)
                .WithOne(c => c.Contract);
        }
    }
}
