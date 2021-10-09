﻿using Domain.Entities.Bidding;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces.Bidding;

namespace Repository.Repositories.Bidding
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public ContractRepository(DbContext context) : base(context)
        {
        }
    }
}
