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
            throw new NotImplementedException();
        }
    }
}
