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
    public class ClauseConfiguration : IEntityTypeConfiguration<Clause>
    {
        public void Configure(EntityTypeBuilder<Clause> builder)
        {
            builder.ToTable("Clause");

            builder.HasKey(c => c.ClauseId);

            builder.Property(c => c.ClauseId)
                .HasColumnType("bigint");
            builder.Property(c => c.Number)
                .HasColumnType("varchar")
                .HasMaxLength(10);
            builder.Property(c => c.Text)
                .HasColumnType("varchar")
                .HasMaxLength(2048);


            builder.HasOne(c => c.Contract)
                .WithMany(c => c.Clauses)
                .HasForeignKey(c => c.ContractId);
        }
    }
}
