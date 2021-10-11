using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class Clause
    {
        public long ClauseId { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }

        public bool Closed { get; set; }

        public long ContractId { get; set; }
        public virtual Contract Contract {  get; set; }
        public long AdditiveID { get; set; }
        public virtual Additive Additive { get; set; }
    }
}
