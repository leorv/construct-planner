using Domain.Entities;
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
    public class AdditiveAgreementConfiguration : IEntityTypeConfiguration<AdditiveAgreement>
    {
        public void Configure(EntityTypeBuilder<AdditiveAgreement> builder)
        {
            builder.ToTable("AdditiveAgreement");

            builder.HasKey(aa => new { aa.UserId, aa.AdditiveId });
            builder.Property(aa => aa.IsAgree)
                .HasColumnType("TINYINT")
                .HasMaxLength(1);

            builder.HasOne(u => u.User)
                .WithMany(aa => aa.AdditiveAgreements)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(a => a.Additive)
                .WithMany(aa => aa.AdditiveAgreements)
                .HasForeignKey(a => a.AdditiveId);

           
        }
    }
}
