using Domain.Entities.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class ContractUserRepository : Repository<ContractUser>, IContractUserRepository
    {
        public ConstructContext ConstructContext
        {
            get
            {
                return Context as ConstructContext;
            }
        }
        public ContractUserRepository(DbContext context) : base(context)
        {

        }
    }
}
