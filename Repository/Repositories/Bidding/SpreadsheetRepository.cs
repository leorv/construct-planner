﻿using Domain.Entities.Bidding;
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
    public class SpreadsheetRepository : Repository<Spreadsheet>, ISpreadsheetRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public SpreadsheetRepository(DbContext context) : base(context)
        {
        }
    }
}