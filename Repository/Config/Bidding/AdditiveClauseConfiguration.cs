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
    public class AdditiveClauseConfiguration : IEntityTypeConfiguration<AdditiveClause>
    {

        public void Configure(EntityTypeBuilder<AdditiveClause> builder)
        {
            builder.ToTable("AdditiveClause");

            builder.HasKey(c => c.AdditiveClauseId);

            builder.Property(c => c.AdditiveClauseId)
                .HasColumnType("bigint");
            builder.Property(c => c.Number)
                .HasColumnType("varchar")
                .HasMaxLength(10);
            builder.Property(c => c.Text)
                .HasColumnType("varchar")
                .HasMaxLength(2048);

            builder.HasOne(a => a.Additive)
            .WithMany(c => c.AdditiveClauses)
            .HasForeignKey(a => a.AdditiveID);
        }

    }
}