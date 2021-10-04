using Domain.Entities.Bidding;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SpreadsheetItemRepository : Repository<SpreadsheetItem>, ISpreadsheetItemRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public SpreadsheetItemRepository(DbContext context) : base(context)
        {
        }
    }
}
