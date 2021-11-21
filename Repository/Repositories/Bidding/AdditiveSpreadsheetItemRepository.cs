using Domain.Entities.Bidding;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class AdditiveSpreadsheetItemRepository : Repository<AdditiveSpreadsheetItem>, IAdditiveSpreadsheetItemRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as  ConstructContext; }
        }
        public AdditiveSpreadsheetItemRepository(ConstructContext context) : base(context)
        {
        }

        // Aqui implementamos os métodos específicos de AdditiveSpreadsheetItems. Por exemplo, GetDetalhes. etc.


    }
}
