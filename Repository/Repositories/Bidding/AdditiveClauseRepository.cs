using Domain.Entities.Bidding;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class AdditiveClauseRepository : Repository<AdditiveClause>, IAdditiveClauseRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as  ConstructContext; }
        }
        public AdditiveClauseRepository(ConstructContext context) : base(context)
        {
        }

        // Aqui implementamos os métodos específicos de AdditiveClauses. Por exemplo, GetDetalhes. etc.


    }
}
