using Domain.Interfaces.Bidding;
using Domain.Entities.Bidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Bidding
{
    public class AdditiveAgreementsRepository : Repository<AdditiveAgreement>, IAdditiveAgreementRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public AdditiveAgreementsRepository(DbContext context) : base(context)
        {
        }
    }
}
