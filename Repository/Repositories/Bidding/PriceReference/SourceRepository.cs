using Domain.Entities.Bidding.PriceReference;
using Domain.Interfaces.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
