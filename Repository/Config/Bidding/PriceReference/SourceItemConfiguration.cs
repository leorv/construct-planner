using Domain.Entities.Bidding.PriceReference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config.Bidding.PriceReference
{
    public class SourceItemConfiguration : IEntityTypeConfiguration<SourceItem>
    {
        public void Configure(EntityTypeBuilder<SourceItem> builder)
        {
            throw new NotImplementedException();
        }
    }
}
