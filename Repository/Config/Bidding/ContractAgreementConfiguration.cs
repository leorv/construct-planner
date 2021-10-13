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
    public class ContractAgreementConfiguration : IEntityTypeConfiguration<ContractAgreement>
    {
        public void Configure(EntityTypeBuilder<ContractAgreement> builder)
        {
            builder.ToTable("ContractAgreement");

            builder.HasKey(ca => ca.ContractId);

            builder.Property(ca => ca.ContractId)
                .HasColumnType("bigint");
            builder.Property(ca => ca.IsAgree)
                .HasColumnType("TINYINT")
                .HasMaxLength(1);

            builder.HasOne(u => u.User)
                .WithMany(ca => ca.ContractAgreements)
                .HasForeignKey(ca => ca.UserId);

            builder.HasOne(c => c.Contract)
                .WithMany(ca => ca.ContractAgreements)
                .HasForeignKey(ca => ca.ContractId);
        }
    }
}
