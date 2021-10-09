using Domain.Entities.Bidding.PriceReference;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding.PriceReference;

namespace Repository.Repositories.Bidding.PriceReference
{
    public class SourceItemRepository : Repository<SourceItem>, ISourceItemRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public SourceItemRepository(DbContext context) : base(context)
        {
        }
    }
}
