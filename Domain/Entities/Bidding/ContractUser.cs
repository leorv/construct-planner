using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class ContractUser
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }
}
