﻿using Domain.Entities.Bidding.PriceReference;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class InputRepository : Repository<Input>, IInputRepository
    {
        public InputRepository(DbContext context) : base(context)
        {
        }
    }
}
