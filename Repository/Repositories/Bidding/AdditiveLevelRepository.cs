using Domain.Entities.Bidding;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class AdditiveLevelRepository : Repository<AdditiveLevel>, IAdditiveLevelRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as  ConstructContext; }
        }
        public AdditiveLevelRepository(ConstructContext context) : base(context)
        {
        }

        // Aqui implementamos os métodos específicos de AdditiveLevels. Por exemplo, GetDetalhes. etc.


    }
}
