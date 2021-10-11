using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config.Common
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(a => a.AddressId);

            builder.Property(a => a.AddressId)
                .HasColumnType("bigint");
            builder.Property(a => a.PostalCode)
                .HasColumnType("varchar")
                .HasMaxLength(16);
            builder.Property(a => a.Street)
                .HasColumnType("varchar")
                .HasMaxLength(128);
            builder.Property(a => a.Number)
                .HasColumnType("varchar")
                .HasMaxLength(10);
            builder.Property(a => a.Complement)
                .HasColumnType("varchar")
                .HasMaxLength(64);
            builder.Property(a => a.District)
                .HasColumnType("varchar")
                .HasMaxLength(64);
            builder.Property(a => a.City)
                .HasColumnType("varchar")
                .HasMaxLength(64);
            builder.Property(a => a.State)
                .HasColumnType("varchar")
                .HasMaxLength(64);
            builder.Property(a => a.Country)
                .HasColumnType("varchar")
                .HasMaxLength(64);

            builder.HasOne(s => s.Spreadsheet)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.SpreadsheetId);
        }
    }
}
