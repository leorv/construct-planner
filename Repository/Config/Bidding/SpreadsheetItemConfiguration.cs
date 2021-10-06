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
    public class SpreadsheetItemConfiguration : IEntityTypeConfiguration<SpreadsheetItem>
    {
        public void Configure(EntityTypeBuilder<SpreadsheetItem> builder)
        {
            throw new NotImplementedException();
        }
    }
}
