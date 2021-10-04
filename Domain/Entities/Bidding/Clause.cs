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

        public ICollection<long> Agreements { get; set; }
        public bool Closed { get; set; }

        public long ContractId { get; set; }
        public Contract Contract {  get; set; }
        public long AdditiveID { get; set; }
        public Additive Additive { get; set; }
    }
}
