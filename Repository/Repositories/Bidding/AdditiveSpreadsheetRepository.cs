using Domain.Entities.Bidding;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class AdditiveSpreadsheetRepository : Repository<AdditiveSpreadsheet>, IAdditiveSpreadsheetRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as  ConstructContext; }
        }
        public AdditiveSpreadsheetRepository(ConstructContext context) : base(context)
        {
        }

        // Aqui implementamos os métodos específicos de AdditiveSpreadsheets. Por exemplo, GetDetalhes. etc.


    }
}
