using Domain.Entities.Bidding.PriceReference;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SourceRepository : Repository<Source>, ISourceRepository
    {
        public SourceRepository(DbContext context) : base(context)
        {
        }
    }
}
