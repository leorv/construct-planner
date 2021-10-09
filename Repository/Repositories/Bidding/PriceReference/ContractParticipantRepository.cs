using Domain.Entities.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding;

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
