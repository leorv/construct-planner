﻿using Domain.Entities.Bidding;
using Domain.Interfaces.Bidding;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
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
