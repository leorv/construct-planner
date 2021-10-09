using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class ContractParticipant
    {
        public long ParticipantId { get; set; }
        public virtual User Participant { get; set; }
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }
}
