﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding.PriceReference
{
    public class Input
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public char Type { get; set; } // S = Serviços ou Mão de obra ; M = Material
        public decimal Price { get; set; }

    }
}
