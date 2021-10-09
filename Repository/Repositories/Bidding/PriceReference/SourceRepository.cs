using Domain.Entities.Bidding.PriceReference;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding.PriceReference;

namespace Repository.Repositories.Bidding.PriceReference
{
    public class SourceRepository : Repository<Source>, ISourceRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public SourceRepository(DbContext context) : base(context)
        {
        }
    }
}
