using Domain.Entities.Common;
using Domain.Interfaces.Common;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
