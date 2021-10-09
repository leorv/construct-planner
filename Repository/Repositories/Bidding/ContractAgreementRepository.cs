using Domain.Entities.Bidding;
using Domain.Interfaces.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
