using Domain.Entities.Bidding;
using Domain.Interfaces.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Bidding
{
    public class AdditiveParticipantRepository : Repository<AdditiveParticipant>, IAdditiveParticipantRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }

        public AdditiveParticipantRepository(DbContext context) : base(context)
        {
        }
    }
}
