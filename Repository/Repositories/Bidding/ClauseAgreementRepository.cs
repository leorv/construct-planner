using Domain.Entities.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class ClauseAgreementRepository : Repository<ClauseAgreement>, IClauseAgreementRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public ClauseAgreementRepository(DbContext context) : base(context) {

        }
    }
}
