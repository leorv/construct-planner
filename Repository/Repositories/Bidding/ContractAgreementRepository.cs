using Domain.Entities.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class ContractAgreementRepository : Repository<ContractAgreement>, IContractAgreementRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as  ConstructContext; }
        }
        public ContractAgreementRepository(DbContext context) : base(context)
        {

        }

    }
}
