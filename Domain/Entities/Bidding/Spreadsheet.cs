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
        public long SpreadsheetId { get; set; }
        public string Name {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string EncumberType { get; set; }
        
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public long AdditiveId { get; set; }
        public virtual Additive Additive { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Level> Levels { get; set; }

    }
}
