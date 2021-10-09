using Domain.Entities.Common;
using Repository.Context;
using Repository.Interfaces.Common;

namespace Repository.Repositories.Common
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public AddressRepository(ConstructContext context) : base(context)
        {
        }
    }
}
