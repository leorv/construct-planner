﻿using Domain.Entities.Bidding;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AdditiveRepository : Repository<Additive>, IAdditiveRepository
    {
        public AdditiveRepository()
        {
        }
    }
}
