using Domain.Entities.Bidding;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class AdditiveRepository : Repository<Additive>, IAdditiveRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as  ConstructContext; }
        }
        public AdditiveRepository(ConstructContext context) : base(context)
        {
        }

        // Aqui implementamos os métodos específicos de Additives. Por exemplo, GetDetalhes. etc.
    }
}
