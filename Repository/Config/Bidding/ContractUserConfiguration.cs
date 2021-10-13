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
    public class ContractUserConfiguration : IEntityTypeConfiguration<ContractUser>
    {
        public void Configure(EntityTypeBuilder<ContractUser> builder)
        {
            builder.ToTable("ContractUser");

            builder.HasKey(c => new { c.UserId, c.ContractId });

            builder.HasOne(u => u.User)
                .WithMany(c => c.ContractUsers)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(c => c.Contract)
                .WithMany(c => c.ContractUsers)
                .HasForeignKey(c => c.ContractId);
        }
    }
}
