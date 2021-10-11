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

            builder.HasOne(c => c.Contract)
                .WithMany(c => c.Clauses)
                .HasForeignKey(c => c.ContractId);

            builder.HasOne(a => a.Additive)
                .WithMany(c => c.Clauses)
                .HasForeignKey(a => a.AdditiveID);
        }
    }
}
