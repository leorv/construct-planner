using Domain.Entities.Bidding;
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
    public class ContractParticipantRepository : Repository<ContractParticipant>, IContractParticipantRepository
    {
        public ConstructContext ConstructContext
        {
            get
            {
                return Context as ConstructContext;
            }
        }
        public ContractParticipantRepository(DbContext context) : base(context)
        {

        }
    }
}
