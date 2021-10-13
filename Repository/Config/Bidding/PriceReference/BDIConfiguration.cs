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
    public class BDIConfiguration : IEntityTypeConfiguration<BDI>
    {
        public void Configure(EntityTypeBuilder<BDI> builder)
        {
            builder.ToTable("BDI");

            builder.Property(b => b.BDIId)
                .HasColumnType("bigint");
            builder.Property(b => b.Number)
                .HasColumnType("int")
                .HasMaxLength(3);
            builder.Property(b => b.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(b => b.PersonnelAdministration)
                .HasColumnType("double");
            builder.Property(b => b.GeneralExpenses)
                .HasColumnType("double");
            builder.Property(b => b.Risks)
                .HasColumnType("double");
            builder.Property(b => b.Insurance)
                .HasColumnType("double");
            builder.Property(b => b.Warranty)
                .HasColumnType("double");
            builder.Property(b => b.FinantialExpenses)
                .HasColumnType("double");
            builder.Property(b => b.Profit)
                .HasColumnType("double");
            builder.Property(b => b.PIS)
                .HasColumnType("double");
            builder.Property(b => b.Cofins)
                .HasColumnType("double");
            builder.Property(b => b.CPRB)
                .HasColumnType("double");
            builder.Property(b => b.ISS)
                .HasColumnType("double");
            builder.Property(b => b.BDIValue)
                .HasColumnType("double");

            builder.HasOne(c => c.Contract)
                .WithMany(b => b.BDIs)
                .HasForeignKey(b => b.ContractId);


        }
    }
}
