using Domain.Entities.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
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
