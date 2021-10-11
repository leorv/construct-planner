using Domain.Entities.Bidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Additive> Additives { get; set; }
        public virtual ICollection<AdditiveAgreement> AdditiveAgreements { get; set; }
        // public virtual ICollection<AdditiveUser> AdditiveUsers { get; set; }
        public virtual ICollection<ContractAgreement> ContractAgreements { get; set; }
        public virtual ICollection<ContractUser> ContractUsers { get; set; }

    }
}
