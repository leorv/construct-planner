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
    public class AdditiveConfiguration : IEntityTypeConfiguration<Additive>
    {
        public void Configure(EntityTypeBuilder<Additive> builder)
        {
            // Variáveis comuns

            builder.ToTable("Additive");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("BIGINT");

            builder.Property(u => u.Name).IsRequired()
                .HasMaxLength(256)
                .HasColumnType("VARCHAR");

            builder.Property(u => u.Number).IsRequired()
                .HasColumnType("INT");

            builder.Property(u => u.Year).IsRequired()
                .HasColumnType("INT");

            builder.Property(u => u.Description).IsRequired()
                .HasColumnType("VARCHAR");

            builder.Property(u => u.Justification).HasColumnType("VARCHAR");

            builder.Property(u => u.TotalValue).HasColumnType("DECIMAL(20,8)");

            // =============================================
            // Relações e Variáveis de posse
            // =============================================
            //    public long AdditiveOwner { get; set; }
            //    public ICollection<long> Participants { get; set; }
            //    public ICollection<long> Agreements { get; set; }
            //    public bool Closed { get; set; }


            // TODO: Adicionar os participantes aqui. Classe usuário.

            builder.Property(u => u.Closed).HasColumnType("BOOL");
            






    }
    }
}
