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
    public class SpreadsheetConfiguration : IEntityTypeConfiguration<Spreadsheet>
    {
        public void Configure(EntityTypeBuilder<Spreadsheet> builder)
        {
            throw new NotImplementedException();
        }
    }
}
