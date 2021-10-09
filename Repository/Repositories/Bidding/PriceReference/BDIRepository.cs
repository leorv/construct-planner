using Domain.Entities.Bidding.PriceReference;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding.PriceReference;

namespace Repository.Repositories.Bidding.PriceReference
{
    public class BDIRepository : Repository<BDI>, IBDIRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public BDIRepository(DbContext context) : base(context)
        {
        }
    }
}
