using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // TODO: implementar essa classe.
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(s => s.UserId);

            builder.Property(s => s.UserId)
                .HasColumnType("bigint");
            builder.Property(s => s.Name)
                .HasColumnType("varchar")
                .HasMaxLength(32);
            builder.Property(s => s.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(128);
            builder.Property(s => s.Email)
                .HasColumnType("varchar")
                .HasMaxLength(256);
            builder.Property(s => s.Password)
                .HasColumnType("varchar");
            builder.Property(s => s.Photo)
                .HasColumnType("varchar");

            builder.HasMany(c => c.Contracts)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(a => a.Additives)
                .WithOne(u => u.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(aa => aa.AdditiveAgreements)
                .WithOne(u => u.User)
                .HasForeignKey(aa => aa.UserId);

            builder.HasMany(ca => ca.ContractAgreements)
                .WithOne(u => u.User)
                .HasForeignKey(ca => ca.UserId);

            builder.HasMany(us => us.ContractUsers)
                .WithOne(u => u.User)
                .HasForeignKey(us => us.UserId);

        }
    }
}
