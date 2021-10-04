using Domain.Entities.Bidding;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ClauseRepository : Repository<Clause>, IClauseRepository
    {
        public ClauseRepository(DbContext context) : base(context)
        {
        }
    }
}
