using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;

namespace Domain.Entities.Bidding
{
    public class Spreadsheet
    {
        public long Id { get; set; }
        public string Name {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        // Relações
        public long ContractId { get; set; }
        public Contract Contract { get; set; }
        public long AdditiveId { get; set; }
        public Additive Additive { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Level> Levels { get; set; }

    }
}
