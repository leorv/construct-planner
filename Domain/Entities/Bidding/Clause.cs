using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class Clause
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
    }
}
