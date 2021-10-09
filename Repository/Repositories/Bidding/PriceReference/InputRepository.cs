using Domain.Entities.Bidding.PriceReference;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding.PriceReference;

namespace Repository.Repositories.Bidding.PriceReference
{
    public class InputRepository : Repository<Input>, IInputRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public InputRepository(DbContext context) : base(context)
        {
        }
    }
}
