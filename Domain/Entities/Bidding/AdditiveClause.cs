using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class AdditiveClause
    {
        public long AdditiveClauseId { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }

        public bool Closed { get; set; }
        public long AdditiveID { get; set; }
        public virtual Additive Additive { get; set; }
    }
}
